using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace PotatoBot.Data
{
    public class BaseConfiguration
    {
        [BsonId]
        public ulong Id { get; set; }
        public string DBName;
        public string TableName;

        public BsonValue Insert()
        {
            return DBWrapper.Insert(DBName, TableName, this);
        }
    }
}
