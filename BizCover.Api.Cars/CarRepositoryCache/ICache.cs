using System;

namespace BizCover.Api.Cars.CarRepositoryCache
{
    public interface ICache
    {
        void Add(string key, object value, DateTimeOffset expirationTime);

        object Get(string key);

        void Remove(string key);
    }
}