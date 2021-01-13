using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace Com.Sapient.Services.RedisService
{
    public class RedisService : IRedisService
    {
        string Server;
        string Port;
        string expiryTime = new TimeSpan(0, 10, 0).ToString();
        private readonly IConfiguration _configuration;

        public RedisService(IConfiguration configuration)
        {
            _configuration = configuration;
            Server = _configuration.GetSection("RedisConnection").GetSection("Server").Value;
            Port = _configuration.GetSection("RedisConnection").GetSection("Port").Value;
            expiryTime = _configuration.GetSection("RedisConnection").GetSection("ExpiryTime").Value;
        }
        public RedisService()
        {

        }

        //Establishes Redis connection
        public IDatabase RedisConnection()
        {
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(Server + ":" + Port);
            IDatabase connection = redisConnection.GetDatabase();
            return connection;
        }
        //Inserts data in Redis database
        public void InsertData(IDatabase connection, string emailId, string token)
        {
            connection.StringSet(emailId,token);
            connection.KeyExpire(emailId, TimeSpan.Parse(expiryTime));
        }
        //Reads data from Redis database
        public string ReadData(IDatabase connection, string userId)
        {
            return connection.StringGet(userId);
        }
        //Deletes data from Redis database
        public void DeleteData(IDatabase connection, string token)
        {
            connection.KeyDelete(token);
        }
    }

}
