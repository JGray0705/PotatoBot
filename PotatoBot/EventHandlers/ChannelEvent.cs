using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class ChannelEvent : BaseEventHandler
    {
        public static Task Client_ChannelUpdated(DiscordClient sender, DSharpPlus.EventArgs.ChannelUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_ChannelPinsUpdated(DiscordClient sender, DSharpPlus.EventArgs.ChannelPinsUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_ChannelDeleted(DiscordClient sender, DSharpPlus.EventArgs.ChannelDeleteEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_ChannelCreated(DiscordClient sender, DSharpPlus.EventArgs.ChannelCreateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_TypingStarted(DiscordClient sender, DSharpPlus.EventArgs.TypingStartEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_WebhooksUpdated(DiscordClient sender, DSharpPlus.EventArgs.WebhooksUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
