using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using PotatoBot.Attributes;
using PotatoBot.Data;
using PotatoBot.EventHandlers;
using PotatoBot.ExtensionMethods;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot
{
    public class DiscordBot
    {
        public ulong[] BotAdmins;
        public ulong LogChannel;
        private readonly string Token;
        private static DiscordClient Client;
        private static CommandsNextExtension Commands;
        private readonly ConcurrentDictionary<ulong, string> GuildPrefixes;

        public DiscordBot(ClientConfiguration clientConfig)
        {
            BotAdmins = clientConfig.BotAdmins;
            LogChannel = clientConfig.LogChannel;
#if DEBUG
            Token = clientConfig.TestToken;
#else
            Token = clientConfig.Token;
#endif
            var config = new DiscordConfiguration()
            {
                Token = Token,
                TokenType = TokenType.Bot
            };

            GuildPrefixes = new ConcurrentDictionary<ulong, string>();

            Client = new DiscordClient(config);

            Commands = Client.UseCommandsNext(new CommandsNextConfiguration()
            {
                PrefixResolver = x => ResolvePrefix(x)
            }) ;

            Commands.CommandErrored += Commands_CommandErrored;
        }

        private async Task Commands_CommandErrored(CommandsNextExtension sender, CommandErrorEventArgs e)
        {
            var ch = await Client.GetChannelAsync(LogChannel);
            switch (e.Exception)
            {
                case ChecksFailedException ex:
                    await ChecksFailedHandler(ex, ch);
                    break;
                case CommandNotFoundException ex:
                    await CommandNotFoundHandler(ex, ch);
                    break;
                case DuplicateCommandException ex:
                    await DuplicateCommandHandler(ex, ch);
                    break;
                case InvalidOverloadException ex:
                    await InvalidOverloadHandler(ex, ch);
                    break;
                default:
                    await UnhandledCommandExceptionHandler(e, ch);
                    break;
            }
        }

        private async static Task UnhandledCommandExceptionHandler(CommandErrorEventArgs e, DiscordChannel logChannel)
        {
            await logChannel.SendLogMessageAsync("Unknown Command Error", e.Exception.Message, LogLevel.Error);
        }

        private async static Task InvalidOverloadHandler(InvalidOverloadException ex, DiscordChannel logChannel)
        {
            var msg = $"Command {ex.Method.Name} failed. Use /help {ex.Method.Name} to get more info on this command";
            await logChannel.SendLogMessageAsync("Invalid Overload", msg, LogLevel.Warning);
        }

        private async static Task DuplicateCommandHandler(DuplicateCommandException ex, DiscordChannel logChannel)
        {
            await logChannel.SendLogMessageAsync("Duplicate Command", ex.Message, LogLevel.Warning);
        }

        private static Task CommandNotFoundHandler(CommandNotFoundException ex, DiscordChannel logChannel)
        {
            return Task.CompletedTask; // may add command suggestions to send the user based on what they typed
        }

        private async static Task ChecksFailedHandler(ChecksFailedException ex, DiscordChannel logChannel)
        {
            var embed = new DiscordEmbedBuilder();
            foreach(var check in ex.FailedChecks)
            {
                string msg, checkName;
                switch(check)
                {
                    case RequireBotPermissionsAttribute at:
                        checkName = "Missing Bot Permissions";
                        msg = $"I am missing the following permissions: {string.Join(", ", at.Permissions)}";
                        break;
                    case RequireDirectMessageAttribute:
                        checkName = "DM Required";
                        msg = "This command must be used in Direct Message";
                        break;
                    case RequireGuildAttribute:
                        checkName = "Guild Required";
                        msg = "This command must be used in a guild/server (Not in direct message)";
                        break;
                    case RequireNsfwAttribute:
                        checkName = "NSFW Required";
                        msg = "This command must be used in an NSFW channel";
                        break;
                    case RequirePermissionsAttribute at:
                        checkName = "Missing Permissions";
                        msg = $"Either you or the bot (or both) is missing the following permissions: {string.Join(", ", at.Permissions)}";
                        break;
                    case RequireRolesAttribute at:
                        checkName = "Missing Roles";
                        msg = $"You are missing required roles to use this command. Missing roles: {string.Join(", ", at.RoleNames)}";
                        break;
                    case RequireUserPermissionsAttribute at:
                        checkName = "Missing Permissions";
                        msg = $"You am missing the following permissions: {string.Join(", ", at.Permissions)}";
                        break;
                    case BaseCustomAttribute at:
                        checkName = at.CheckName;
                        msg = at.CheckMessage;
                        break;
                    default:
                        checkName = "Unknown Check Failed";
                        msg = $"Check Failed {check.GetType().Name}";
                        break;
                }
                embed.AddField(checkName, msg);
            }
            embed.WithColor(DiscordColor.Red);
            embed.WithTitle($"Command {ex.Command.Name} failed");
            await ex.Context.RespondAsync(embed: embed);
        }

        public async Task RunAsync()
        {
            var activity = new DiscordActivity("with startup code.", ActivityType.Playing);
            await Client.ConnectAsync(activity);
            var channel = await Client.GetChannelAsync(LogChannel);
            BaseEventHandler.SetUpEvents(Client, channel);
            await Task.Delay(-1);
        }

        private async Task<int> ResolvePrefix(DiscordMessage msg)
        {
            return msg.GetStringPrefixLength(GetPrefix(msg.Channel.GuildId) ?? "/", StringComparison.InvariantCultureIgnoreCase);
        }

        private string GetPrefix(ulong guildId)
        {
            if (GuildPrefixes.TryGetValue(guildId, out string prefix))
            {
                return prefix;
            }
            var p = GuildData.GetPrefix(guildId);
            if (!string.IsNullOrEmpty(p)) GuildPrefixes.TryAdd(guildId, p);
            return p;
        }
    }
}
