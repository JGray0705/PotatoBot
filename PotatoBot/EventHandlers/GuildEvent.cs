using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PotatoBot.EventHandlers
{
    public class GuildEvent : BaseEventHandler
    {
        public static Task Client_GuildUpdated(DiscordClient sender, DSharpPlus.EventArgs.GuildUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildUnavailable(DiscordClient sender, DSharpPlus.EventArgs.GuildDeleteEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildIntegrationsUpdated(DiscordClient sender, DSharpPlus.EventArgs.GuildIntegrationsUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildEmojisUpdated(DiscordClient sender, DSharpPlus.EventArgs.GuildEmojisUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static async Task Client_GuildDownloadCompleted(DiscordClient sender, DSharpPlus.EventArgs.GuildDownloadCompletedEventArgs e)
        {
            // update user status.. for fun
            var memberCount = e.Guilds.Sum(x => x.Value.MemberCount);
            await sender.UpdateStatusAsync(new DSharpPlus.Entities.DiscordActivity(e.Guilds.Count + " guilds and " + memberCount + " members.", DSharpPlus.Entities.ActivityType.Watching));
        }

        public static Task Client_GuildDeleted(DiscordClient sender, DSharpPlus.EventArgs.GuildDeleteEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildCreated(DiscordClient sender, DSharpPlus.EventArgs.GuildCreateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildBanRemoved(DiscordClient sender, DSharpPlus.EventArgs.GuildBanRemoveEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildBanAdded(DiscordClient sender, DSharpPlus.EventArgs.GuildBanAddEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_GuildAvailable(DiscordClient sender, DSharpPlus.EventArgs.GuildCreateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_InviteDeleted(DiscordClient sender, DSharpPlus.EventArgs.InviteDeleteEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_InviteCreated(DiscordClient sender, DSharpPlus.EventArgs.InviteCreateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_VoiceServerUpdated(DiscordClient sender, DSharpPlus.EventArgs.VoiceServerUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }

        public static Task Client_VoiceStateUpdated(DiscordClient sender, DSharpPlus.EventArgs.VoiceStateUpdateEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
