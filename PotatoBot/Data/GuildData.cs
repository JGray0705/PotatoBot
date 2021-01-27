using System;
using System.Collections.Generic;
using System.Text;

namespace PotatoBot.Data
{
    public class GuildData
    {
        private const string DBName = "Guilds.db";
        private const string TableName = "GuildConfiguration";

        public static string GetPrefix(ulong id)
        {
            var guild = DBWrapper.FindOne<GuildConfiguration>(DBName, TableName, x => x.Id == id);
            return guild?.Prefix;
        }

        public static bool Update(GuildConfiguration config)
        {
            return DBWrapper.Update(DBName, TableName, config);
        }

        public static bool Upsert(GuildConfiguration config)
        {
            return DBWrapper.Upsert(DBName, TableName, config);
        }

        public static GuildConfiguration FindByID(ulong id)
        {
            return DBWrapper.FindOne<GuildConfiguration>(DBName, TableName, x => x.Id == id);
        }

        public static ulong GetLogChannel(ulong guildId)
        {
            var guild = FindByID(guildId);
            return guild == null ? 0 : guild.LogChannel;
        }

        public static bool CustomCommandsEnabled(ulong guildId)
        {
            return FindByID(guildId).CustomCommandsEnabled;
        }
    }
}
