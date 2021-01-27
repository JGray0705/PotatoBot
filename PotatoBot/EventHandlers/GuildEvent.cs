using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PotatoBot.Data;
using DSharpPlus.Entities;
using PotatoBot.ExtensionMethods;
using Microsoft.Extensions.Logging;

namespace PotatoBot.EventHandlers
{
    public class GuildEvent : BaseEventHandler
    {
        public static async Task Client_GuildUpdated(DiscordClient sender, DSharpPlus.EventArgs.GuildUpdateEventArgs e)
        {
            var ch = await GetLogChannel(sender, e.GuildAfter.Id);
            if (ch == null) return;
            var changes = SnowflakeChanges.CompareGuildChanges(e.GuildBefore, e.GuildAfter);
            if(changes.Count > 0) await ch.SendLogMessageAsync("Server Updated", $"The following server properties were changed:\n {string.Join("\n\n", changes)}", LogLevel.Information);
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
            await sender.UpdateStatusAsync(new DiscordActivity(e.Guilds.Count + " guilds and " + memberCount + " members.", ActivityType.Watching));
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

        private static async Task<DiscordChannel> GetLogChannel(DiscordClient client, ulong guildId)
        {
            var logChannelId = GuildData.GetLogChannel(guildId);
            if (logChannelId == 0) return null;
            return await client.GetChannelAsync(logChannelId);
        }
    }
}
