using BizCover.Api.Cars.CarRepositoryCache;
using BizCover.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BizCover.Api.Cars.Services.GetAllCars
{
    public class GetAllCarsService : IGetAllCarsService
    {
        private ICarRepositoryCache _carRepositoryCache;

        public GetAllCarsService(ICarRepositoryCache carRepositoryCache)
        {
            _carRepositoryCache = carRepositoryCache;
        }

        public async Task<IReadOnlyList<Repository.Cars.Car>> GetAllCars()
        {
            return await _carRepositoryCache.GetAllCars();
        }
    }
}