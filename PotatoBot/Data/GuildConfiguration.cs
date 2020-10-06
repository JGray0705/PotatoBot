using System;
using System.Collections.Generic;
using System.Text;

namespace PotatoBot.Data
{
    // defines settings that can be adjusted per guild
    public class GuildConfiguration : BaseConfiguration
    {
        public string Prefix { get; set; }
        public ulong DefaultLogChannel { get; set; } // TODO: might allow users to have different log channels depending on what is being logged. Ex: channel1 logs user bans, channel2 logs user join etc.
        public bool CustomCommandsEnabled { get; set; }
        public string[] DisabledModules { get; set; }

        public GuildConfiguration()
        {
            DBName = "Guilds.db";
            TableName = "GuildConfiguration";
        }
    }
}
