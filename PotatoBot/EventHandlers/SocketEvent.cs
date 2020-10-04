using DSharpPlus;
using Microsoft.Extensions.Logging;
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
            sender.Logger.LogInformation("Socket Opened.");
            return Task.CompletedTask;
        }

        public static Task Client_SocketErrored(DiscordClient sender, DSharpPlus.EventArgs.SocketErrorEventArgs e)
        {
            sender.Logger.LogError("Socket Error: " + e.Exception);
            return Task.CompletedTask;
        }

        public static Task Client_SocketClosed(DiscordClient sender, DSharpPlus.EventArgs.SocketCloseEventArgs e)
        {
            sender.Logger.LogInformation("Socket Closed.");
            return Task.CompletedTask;
        }
    }
}
