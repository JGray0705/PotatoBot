using System;
using System.Collections.Generic;
using System.Text;

namespace PotatoBot.Data
{
    public class ChannelConfiguration : BaseConfiguration
    {
        public ulong GuildId { get; set; }
        public bool IsIgnored { get; set; }

        public ChannelConfiguration()
        {
            DBName = "Guilds.db";
            TableName = "ChannelConfiguration";
        }
    }
}
