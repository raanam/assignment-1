using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace BizCover.Api.Cars.CarRepositoryCache
{
    public class Cache : ICache
    {
        private MemoryCache _cache;

        public Cache(MemoryCache cache)
        {
            _cache = cache;
        }

        public Object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Add(string key, object value, DateTimeOffset expirationTime)
        {
            _cache.Add(key, value, expirationTime);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}