using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class RoleEvent : BaseEventHandler
    {
        public static Task Client_GuildRoleUpdated(DiscordClient sender, DSharpPlus.EventArgs.GuildRoleUpdateEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_GuildRoleDeleted(DiscordClient sender, DSharpPlus.EventArgs.GuildRoleDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_GuildRoleCreated(DiscordClient sender, DSharpPlus.EventArgs.GuildRoleCreateEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
