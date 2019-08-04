using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.CarRepositoryCache
{
    public class CarRepositoryCache : ICarRepositoryCache
    {
        private const string CACHE_KEY = "ALL_CARS";

        private ICache _cache;

        private ICarRepository _carRepository;

        public CarRepositoryCache(ICache cache, ICarRepository carRepository)
        {
            _cache = cache;
            _carRepository = carRepository;
        }

        public async Task<IReadOnlyList<Car>> GetAllCars()
        {
            var allCars = _cache.Get(CACHE_KEY) as List<Car>;

            if (allCars == null)
            {
                allCars = await _carRepository.GetAllCars();

                var offset = DateTime.UtcNow.AddHours(24);
                _cache.Add(CACHE_KEY, allCars, new DateTimeOffset(offset));
            }

            return allCars;
        }

        public void InvalidateCache()
        {
            _cache.Remove(CACHE_KEY);
        }
    }
}