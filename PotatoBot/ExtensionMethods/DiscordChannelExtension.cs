using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.ExtensionMethods
{
    public static class DiscordChannelExtension
    {
        public static async Task SendLogMessageAsync(this DiscordChannel channel, string title, string message, LogLevel level)
        {
            var color = level switch
            {
                LogLevel.Information => DiscordColor.CornflowerBlue,
                LogLevel.Error => DiscordColor.Red,
                LogLevel.Warning => DiscordColor.Yellow,
                LogLevel.Critical => DiscordColor.DarkRed,
                LogLevel.Debug => DiscordColor.Blue,
                _ => DiscordColor.White,
            };

            var embed = new DiscordEmbedBuilder()
            {
                Title = title,
                Description = message,
                Color = color
            };
            await channel.SendMessageAsync(embed: embed);
        }
    }
}
