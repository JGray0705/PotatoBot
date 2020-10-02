using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class SocketEvent : BaseEventHandler
    {
        public static Task Client_SocketOpened(DiscordClient sender, DSharpPlus.EventArgs.SocketEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_SocketErrored(DiscordClient sender, DSharpPlus.EventArgs.SocketErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Task Client_SocketClosed(DiscordClient sender, DSharpPlus.EventArgs.SocketCloseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
