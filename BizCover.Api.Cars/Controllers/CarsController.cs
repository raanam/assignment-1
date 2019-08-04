using BizCover.Api.Cars.Services.AddCar;
using BizCover.Repository.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;
using BizCover.Api.Cars.Common;
using BizCover.Api.Cars.Services.GetAllCars;
using BizCover.Api.Cars.Services.UpdateCar;

namespace BizCover.Api.Cars.Controllers
{
    public class CarsController : ApiController
    {
        private IAddCarService _addCarService;

        private IGetAllCarsService _getAllCarsService;

        private IUpdateCarService _updateCarService;

        public CarsController(
            IAddCarService addCarService, 
            IGetAllCarsService getAllCarsService, 
            IUpdateCarService updateCarService)
        {
            _addCarService = addCarService;
            _getAllCarsService = getAllCarsService;
            _updateCarService = updateCarService;
        }

        // Below is just the sample code from the Visual Studio Web Api Template. 
        // Feel free to replace this with whatever implementation you feel is suitable and production ready for a web api.

        // Calling the 3rd party api is expensive and its data only gets updated every 24 hours. Caching can help with this.

        // The repository BizCover.Repository.Cars can be found in ../packages/BizCover.Repository.Cars.1.0.0/BizCover.Repository.Cars.dll. You can restructure this solution as you like.

        // GET api/values
        public  Task<IReadOnlyList<Car>> Get()
        {
            return _getAllCarsService.GetAllCars();
        }

        [ValidateModel]
        [System.Web.Mvc.HttpPost]
        public Task<Car> Create(AddCarRequest request)
        {
            return _addCarService.AddCar(request);
        }

        [ValidateModel]
        [System.Web.Mvc.HttpPut]
        public Task<Car> Put(UpdateCarRequest request)
        {
            return _updateCarService.Update(request);
        }
    }
}
