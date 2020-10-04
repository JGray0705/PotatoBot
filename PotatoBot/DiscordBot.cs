using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using PotatoBot.EventHandlers;
using System;
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

            Client = new DiscordClient(config);

            BaseEventHandler.SetUpEvents(Client, LogChannel);

            Commands = Client.UseCommandsNext(new CommandsNextConfiguration()
            {
                //PrefixResolver = //some method that returns position of prefix in the string
            });
        }

        public async Task RunAsync()
        {
            var activity = new DiscordActivity("with startup code.", ActivityType.Playing);
            await Client.ConnectAsync(activity);
            await Task.Delay(-1);
        }
    }
}
