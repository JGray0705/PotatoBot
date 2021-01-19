using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace PotatoBot.Data
{
    public class ChannelConfiguration
    {
        [BsonId]
        public ulong Id { get; set; }
        public ulong GuildId { get; set; }
        public bool IsIgnored { get; set; }
    }
}
