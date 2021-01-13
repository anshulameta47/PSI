using StackExchange.Redis;

namespace Com.Sapient.Services.RedisService
{
    public interface IRedisService
    {
        IDatabase RedisConnection();
        void InsertData(IDatabase connection, string userId, string token);
        string ReadData(IDatabase connection, string userId);
        void DeleteData(IDatabase connection, string userId);


    }
}
