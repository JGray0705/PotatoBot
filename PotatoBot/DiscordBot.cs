using DSharpPlus;
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
            BaseEventHandler.AddEventListeners(Client);
        }

        public async Task Client_UnknownEvent(DiscordClient sender, DSharpPlus.EventArgs.UnknownEventArgs e)
        {
            var msg = "Unknown Event Triggered: " + e.EventName;
            sender.Logger.LogWarning(msg);
            await (await Client.GetChannelAsync(LogChannel)).SendMessageAsync(msg);
        }

        public async Task RunAsync()
        {
            var activity = new DiscordActivity("with startup code.", ActivityType.Playing);
            await Client.ConnectAsync(activity);
            await Task.Delay(-1);
        }
    }
}
