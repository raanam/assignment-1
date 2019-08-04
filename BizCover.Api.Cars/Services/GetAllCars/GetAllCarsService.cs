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
        private ICarRepository _carRepository;

        public GetAllCarsService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IReadOnlyList<Repository.Cars.Car>> GetAllCars()
        {
            return await _carRepository.GetAllCars();
        }
    }
}