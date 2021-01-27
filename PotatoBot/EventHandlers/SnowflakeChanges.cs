using DSharpPlus.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.EventHandlers
{
    public class SnowflakeChanges
    {
        public string PropertyName { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
        public bool IsImage { get; set; }

        public SnowflakeChanges(string name, string before, string after, bool isImage = false)
        {
            PropertyName = name;
            ValueBefore = before;
            ValueAfter = after;
            IsImage = isImage;
        }

        public static List<SnowflakeChanges> CompareGuildChanges(DiscordGuild before, DiscordGuild after)
        {
            var changes = new List<SnowflakeChanges>();

            if(after?.AfkChannel != null && before?.AfkChannel != after.AfkChannel)
            {
                changes.Add(new SnowflakeChanges("AFK Channel", before.AfkChannel?.Mention, after.AfkChannel.Mention));
            }

            if(before?.AfkTimeout != after.AfkTimeout)
            {
                changes.Add(new SnowflakeChanges("AFK Timeout", before.AfkTimeout / 60 + " minutes", after.AfkTimeout / 60 + " minutes"));
            }
            
            if(!string.IsNullOrEmpty(after.BannerUrl) && before.BannerUrl != after.BannerUrl)
            {
                changes.Add(new SnowflakeChanges("Banner", before.BannerUrl, after.BannerUrl, true));
            }

            if(before.DefaultMessageNotifications != after.DefaultMessageNotifications)
            {
                changes.Add(new SnowflakeChanges("Default Notifications", before.DefaultMessageNotifications.ToString(), after.DefaultMessageNotifications.ToString()));
            }

            if (!string.IsNullOrEmpty(after.Description) && before.Description != after.Description)
            {
                changes.Add(new SnowflakeChanges("Description", before.Description, after.Description));
            }

            if(before.ExplicitContentFilter != after.ExplicitContentFilter)
            {
                changes.Add(new SnowflakeChanges("Explicit Content Filter", before.ExplicitContentFilter.ToString(), after.ExplicitContentFilter.ToString()));
            }

            if(!Enumerable.SequenceEqual(before.Features, after.Features))
            {
                changes.Add(new SnowflakeChanges("Features", string.Join(",", before.Features), string.Join(",", after.Features)));
            }

            if (!string.IsNullOrEmpty(after.IconUrl) && before.IconUrl != after.IconUrl)
            {
                changes.Add(new SnowflakeChanges("Icon", before.IconUrl, after.IconUrl, true));
            }

            if (before.MfaLevel != after.MfaLevel)
            {
                changes.Add(new SnowflakeChanges("Mfa Level", before.MfaLevel.ToString(), after.MfaLevel.ToString()));
            }

            if(before.Owner != after.Owner)
            {
                changes.Add(new SnowflakeChanges("Owner", before.Name, after.Name));
            }

            if(before.SplashUrl != after.SplashUrl)
            {
                changes.Add(new SnowflakeChanges("Splash URL", before.SplashUrl, after.SplashUrl, true));
            }

            if (after?.SystemChannel != null && before?.SystemChannel != after.SystemChannel)
            {
                changes.Add(new SnowflakeChanges("System Channel", before.SystemChannel?.Mention, after.SystemChannel.Mention));
            }

            if (!string.IsNullOrEmpty(after.VanityUrlCode) && before.Description != after.VanityUrlCode)
            {
                changes.Add(new SnowflakeChanges("Vanity Url", before.VanityUrlCode, after.VanityUrlCode));
            }

            if(before.VoiceRegion != after.VoiceRegion)
            {
                changes.Add(new SnowflakeChanges("Voice Region", before.VoiceRegion.Name, after.VoiceRegion.Name));
            }

            if (before.VerificationLevel != after.VerificationLevel)
            {
                changes.Add(new SnowflakeChanges("Verification Level", before.VerificationLevel.ToString(), after.VerificationLevel.ToString()));
            }

            return changes;
        }

        public override string ToString()
        {
            return $"**{PropertyName}**:\nOld value: {ValueBefore}\nNew value: {ValueAfter}";
        }
    }
}
