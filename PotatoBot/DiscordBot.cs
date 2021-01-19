using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using PotatoBot.Data;
using PotatoBot.EventHandlers;
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
        public static DiscordClient Client;
        public static CommandsNextExtension Commands;
        private ConcurrentDictionary<ulong, string> GuildPrefixes;

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
            if (GuildPrefixes.TryGetValue(msg.Channel.GuildId, out string prefix))
            {
                return msg.GetStringPrefixLength(prefix ?? "/", StringComparison.InvariantCultureIgnoreCase);
            }
            var p = GuildData.GetPrefix(msg.Channel.GuildId);
            GuildPrefixes.TryAdd(msg.Channel.GuildId, p);
            return msg.GetStringPrefixLength(p ?? "/", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
