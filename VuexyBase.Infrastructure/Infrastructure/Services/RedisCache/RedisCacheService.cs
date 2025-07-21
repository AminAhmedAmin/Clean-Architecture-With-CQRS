using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Infrastructure.RedisCache;

namespace VuexyBase.Infrastructure.Infrastructure.Services.RedisCache
{
    //public class RedisCacheService : IRedisCacheService
    //{
    //    private readonly IDatabase _database;

    //    public RedisCacheService(IConnectionMultiplexer redis)
    //    {
    //        _database = redis.GetDatabase();
    //    }

    //    public async Task<string?> GetValueAsync(string key)
    //    {
    //        return await _database.StringGetAsync(key);
    //    }

    //    public async Task SetValueAsync(string key, string value, TimeSpan? expiry = null)
    //    {
    //        await _database.StringSetAsync(key, value, expiry ?? TimeSpan.FromHours(1));
    //    }
    //}
}
