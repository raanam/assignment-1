using BizCover.Api.Cars.CarRepositoryCache;
using BizCover.Api.Cars.Services.AddCar;
using BizCover.Api.Cars.Services.GetAllCars;
using BizCover.Api.Cars.Services.Discount;
using BizCover.Repository.Cars;
using System.Runtime.Caching;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BizCover.Api.Cars
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            var memoryCache = new MemoryCache("CarsCache");
            container.RegisterInstance<MemoryCache>(memoryCache);

            // Repositories.
            container.RegisterType<ICarRepository, CarRepository>();
            container.RegisterType<ICarRepositoryCache, CarRepositoryCache.CarRepositoryCache>();

            // Services.
            container.RegisterType<IAddCarService, AddCarService>();
            container.RegisterType<IAddCarRequestMapper, AddCarRequestMapper>();
            container.RegisterType<IGetAllCarsService, GetAllCarsService>();
            container.RegisterType<ICache, Cache>();
            container.RegisterType<IDiscountCalculatorService, DiscountCalculatorService>();
            container.RegisterType<IDiscountCalculator, DiscountForQuantity>("DiscountForQuantity");
            container.RegisterType<IDiscountCalculator, DiscountForManufacturedYear>("DiscountForManufacturedYear");
        }
    }
}