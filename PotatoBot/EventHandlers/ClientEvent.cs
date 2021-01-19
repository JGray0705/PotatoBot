using DSharpPlus;
using Microsoft.Extensions.Logging;
using PotatoBot.ExtensionMethods;
using System;
using DSharpPlus.EventArgs;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PotatoBot.EventHandlers
{
    public class ClientEvent : BaseEventHandler
    {
        public static async Task Client_Ready(DiscordClient sender, ReadyEventArgs e)
        {
            sender.Logger.LogInformation("Client ready!");
            await LogChannel.SendLogMessageAsync("Client ready", $"Client started at {DateTime.Now}", LogLevel.Information);
            e.Handled = true;
        }

        public static async Task Client_ClientErrored(DiscordClient sender, ClientErrorEventArgs e)
        {
            sender.Logger.LogError(e.Exception.Message);
            await LogChannel.SendLogMessageAsync(e.EventName, e.Exception.Message, LogLevel.Error);
        }

        public static async Task Client_Heartbeated(DiscordClient sender, HeartbeatEventArgs e)
        {
            var memberCount = sender.Guilds.Sum(x => x.Value.MemberCount);
            await sender.UpdateStatusAsync(new DSharpPlus.Entities.DiscordActivity(sender.Guilds.Count + " guilds and " + memberCount + " members.", DSharpPlus.Entities.ActivityType.Watching));
        }

        public static async Task Client_UnknownEvent(DiscordClient sender, UnknownEventArgs e)
        {
            var msg = "Unknown Event Triggered: " + e.EventName;
            sender.Logger.LogWarning(msg);
            await LogChannel.SendLogMessageAsync("Unknow Event", msg, LogLevel.Warning);
        }
    }
}
