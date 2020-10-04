using DSharpPlus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class ClientEvent : BaseEventHandler
    {
        public static async Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            sender.Logger.LogInformation("Client ready!");
            await (await sender.GetChannelAsync(LogChannel)).SendMessageAsync("Client ready!");
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
            return Task.CompletedTask; // not sure anything needs to be done here, but added just in case
        }

        public static async Task Client_UnknownEvent(DiscordClient sender, DSharpPlus.EventArgs.UnknownEventArgs e)
        {
            var msg = "Unknown Event Triggered: " + e.EventName;
            sender.Logger.LogWarning(msg);
            await (await sender.GetChannelAsync(LogChannel)).SendMessageAsync(msg);
        }
    }
}
