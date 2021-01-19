using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class MemberEvent : BaseEventHandler
    {
        public static Task Client_GuildMemberUpdated(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildMembersChunked(DiscordClient sender, DSharpPlus.EventArgs.GuildMembersChunkEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildMemberRemoved(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberRemoveEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildMemberAdded(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberAddEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
