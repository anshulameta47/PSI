
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Com.Sapient.Data
{
    public class RedisContext
    {
        //Establishes Redis connection
         public static IDatabase RedisConnection ()
        {
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase connection= redisConnection.GetDatabase();
            return connection;
        }
        //Inserts data in Redis database
        public void  InsertData(string userId,string token)
        {
            RedisConnection().StringSet(userId, token);
        }
        //Reads data from Redis database
        public string ReadData(string userId)
        {
            return RedisConnection().StringGet(userId);
        }
    }
}
