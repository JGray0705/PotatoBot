﻿using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class MessageEvent : BaseEventHandler
    {
        public static Task Client_MessageUpdated(DiscordClient sender, DSharpPlus.EventArgs.MessageUpdateEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_MessagesBulkDeleted(DiscordClient sender, DSharpPlus.EventArgs.MessageBulkDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_MessageReactionsCleared(DiscordClient sender, DSharpPlus.EventArgs.MessageReactionsClearEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_MessageReactionRemovedEmoji(DiscordClient sender, DSharpPlus.EventArgs.MessageReactionRemoveEmojiEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_MessageReactionRemoved(DiscordClient sender, DSharpPlus.EventArgs.MessageReactionRemoveEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_MessageReactionAdded(DiscordClient sender, DSharpPlus.EventArgs.MessageReactionAddEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_MessageDeleted(DiscordClient sender, DSharpPlus.EventArgs.MessageDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_MessageCreated(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
