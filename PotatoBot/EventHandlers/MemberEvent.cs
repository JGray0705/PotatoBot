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
            throw new NotImplementedException();
        }

        public static Task Client_GuildMembersChunked(DiscordClient sender, DSharpPlus.EventArgs.GuildMembersChunkEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_GuildMemberRemoved(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberRemoveEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_GuildMemberAdded(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberAddEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
