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
            return Task.CompletedTask;
        }

        public static Task Client_GuildRoleDeleted(DiscordClient sender, DSharpPlus.EventArgs.GuildRoleDeleteEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildRoleCreated(DiscordClient sender, DSharpPlus.EventArgs.GuildRoleCreateEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
