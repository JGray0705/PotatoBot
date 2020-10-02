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
            Token = config.Token;
#endif
            var config = new DiscordConfiguration()
            {
                Token = Token,
                TokenType = TokenType.Bot
            };

            Client = new DiscordClient(config);
            BaseEventHandler.AddEventListeners(Client);
        }

        /*private void AddEvents()
        {
            Client.ChannelCreated += Client_ChannelCreated;
            Client.ChannelDeleted += Client_ChannelDeleted;
            Client.ChannelPinsUpdated += Client_ChannelPinsUpdated;
            Client.ChannelUpdated += Client_ChannelUpdated;
            Client.ClientErrored += Client_ClientErrored;
            Client.GuildAvailable += Client_GuildAvailable;
            Client.GuildBanAdded += Client_GuildBanAdded;
            Client.GuildBanRemoved += Client_GuildBanRemoved;
            Client.GuildCreated += Client_GuildCreated;
            Client.GuildDeleted += Client_GuildDeleted;
            Client.GuildDownloadCompleted += Client_GuildDownloadCompleted;
            Client.GuildEmojisUpdated += Client_GuildEmojisUpdated;
            Client.GuildIntegrationsUpdated += Client_GuildIntegrationsUpdated;
            
            
            Client.GuildUnavailable += Client_GuildUnavailable;
            Client.GuildUpdated += Client_GuildUpdated;
            Client.Heartbeated += Client_Heartbeated;
            Client.InviteCreated += Client_InviteCreated;
            Client.InviteDeleted += Client_InviteDeleted;
            Client.MessageCreated += Client_MessageCreated;
            Client.MessageDeleted += Client_MessageDeleted;
            Client.MessageReactionAdded += Client_MessageReactionAdded;
            Client.MessageReactionRemoved += Client_MessageReactionRemoved;
            Client.MessageReactionRemovedEmoji += Client_MessageReactionRemovedEmoji;
            Client.MessageReactionsCleared += Client_MessageReactionsCleared;
            Client.MessagesBulkDeleted += Client_MessagesBulkDeleted;
            Client.MessageUpdated += Client_MessageUpdated;
            Client.PresenceUpdated += Client_PresenceUpdated;
            Client.Ready += Client_Ready;
            Client.Resumed += Client_Resumed;
            Client.SocketClosed += Client_SocketClosed;
            Client.SocketErrored += Client_SocketErrored;
            Client.SocketOpened += Client_SocketOpened;
            Client.TypingStarted += Client_TypingStarted;
            Client.UnknownEvent += Client_UnknownEvent;
            Client.VoiceServerUpdated += Client_VoiceServerUpdated;
            Client.VoiceStateUpdated += Client_VoiceStateUpdated;
            Client.WebhooksUpdated += Client_WebhooksUpdated;
        }   */

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
