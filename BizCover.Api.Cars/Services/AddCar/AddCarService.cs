using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.AddCar
{
    public class AddCarService : IAddCarService
    {
        private ICarRepository _carRepository;

        public AddCarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<Car> AddCar(IAddCarRequest addCarRequest)
        {
            throw new NotImplementedException();
        }
    }
}