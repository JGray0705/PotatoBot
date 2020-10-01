using DSharpPlus;
using DSharpPlus.Entities;
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
        private string Token;
        public static DiscordClient Client;

        public DiscordBot(ClientConfiguration clientConfig)
        {
            BotAdmins = clientConfig.BotAdmins;
            LogChannel = clientConfig.LogChannel;
#if DEBUG
            Token = clientConfig.TestToken;
#else
            Token = config.Token;
#endif
            var config = new DiscordConfiguration()
            {
                Token = Token,
                TokenType = TokenType.Bot,
            };

            Client = new DiscordClient(config);
        }

        public async Task RunAsync()
        {
            var activity = new DiscordActivity("with startup code.", ActivityType.Playing);
            await Client.ConnectAsync(activity);
            await Task.Delay(-1);
        }
    }
}
