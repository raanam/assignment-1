using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BizCover.Api.Cars.CarRepositoryCache;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.UpdateCar
{
    public class UpdateCarService : IUpdateCarService
    {
        private ICarRepositoryCache _carRepositoryCache;
        private ICarRepository _carRepository;
        private IUpdateCarRequestMapper _updateCarRequestMapper;

        public UpdateCarService(ICarRepositoryCache carRepositoryCache, ICarRepository carRepository, IUpdateCarRequestMapper updateCarRequestMapper)
        {
            _carRepositoryCache = carRepositoryCache;
            _carRepository = carRepository;
            _updateCarRequestMapper = updateCarRequestMapper;
        }

        public async Task<Car> Update(IUpdateCarRequest updateCarRequest)
        {
            // TODO: We need Get by id in repository.
            var allCars = await _carRepositoryCache.GetAllCars();
            var carToUpdate = allCars.Where(c => c.Id == updateCarRequest.Id).FirstOrDefault();

            if (carToUpdate == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var mappedRequest = _updateCarRequestMapper.Map(updateCarRequest);
            await _carRepository.Update(mappedRequest);

            _carRepositoryCache.InvalidateCache();

            return mappedRequest;
        }
    }
}