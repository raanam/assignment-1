using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BizCover.Api.Cars.CarRepositoryCache;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.AddCar
{
    public class AddCarService : IAddCarService
    {
        private ICarRepository _carRepository;
        private IAddCarRequestMapper _addCarRequestMapper;
        private ICarRepositoryCache _carRepositoryCache;

        public AddCarService(ICarRepository carRepository, 
                             IAddCarRequestMapper addCarRequestMapper,
                             ICarRepositoryCache carRepositoryCache)
        {
            _carRepository = carRepository;
            _addCarRequestMapper = addCarRequestMapper;
            _carRepositoryCache = carRepositoryCache;
        }

        public async Task<Car> AddCar(IAddCarRequest addCarRequest)
        {
            var request = _addCarRequestMapper.Map(addCarRequest);

            var id = await _carRepository.Add(request);
            request.Id = id;

            _carRepositoryCache.InvalidateCache();
            return request;
        }
    }
}