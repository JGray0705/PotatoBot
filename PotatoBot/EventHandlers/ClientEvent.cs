using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class ClientEvent : BaseEventHandler
    {
        public static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_ClientErrored(DiscordClient sender, DSharpPlus.EventArgs.ClientErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_Heartbeated(DiscordClient sender, DSharpPlus.EventArgs.HeartbeatEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_Resumed(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_PresenceUpdated(DiscordClient sender, DSharpPlus.EventArgs.PresenceUpdateEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
