using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PotatoBot.Data
{
    public class DBWrapper
    {
        public static BsonValue Insert<T>(string dbName, string tableName, T data)
        {
            using var db = new LiteDatabase(dbName);
            var table = db.GetCollection<T>(tableName);
            return table.Insert(data);
        }

        public static IEnumerable<T> Find<T>(string dbName, string tableName, Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            using var db = new LiteDatabase(dbName);
            var table = db.GetCollection<T>(tableName);
            return table.Find(predicate, skip, limit);
        }

        public static T FindOne<T>(string dbName, string tableName, Expression<Func<T, bool>> predicate)
        {
            using var db = new LiteDatabase(dbName);
            var table = db.GetCollection<T>(tableName);
            return table.FindOne(predicate);
        }

        public static bool Update<T>(string dbName, string tableName, T data)
        {
            using var db = new LiteDatabase(dbName);
            var table = db.GetCollection<T>(tableName);
            // returns false if item not found
            return table.Update(data);
        }

        public static int UpdateMany<T>(string dbName, string tableName, IEnumerable<T> data)
        {
            using var db = new LiteDatabase(dbName);
            var table = db.GetCollection<T>(tableName);
            // returns number of items updated
            return table.Update(data);
        }

        public static IEnumerable<T> GetAll<T>(string dbName, string tableName)
        {
            using var db = new LiteDatabase(dbName);
            var table = db.GetCollection<T>(tableName);
            return table.FindAll();
        }

        public static bool Upsert<T>(string dbName, string tableName, T data)
        {
            using var db = new LiteDatabase(dbName);
            var table = db.GetCollection<T>(tableName);
            return table.Upsert(data);
        }
    }
}
