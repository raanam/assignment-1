using BizCover.Api.Cars.Services.AddCar;
using BizCover.Repository.Cars;
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

            // Repositories.
            container.RegisterType<ICarRepository, CarRepository>();

            // Services.
            container.RegisterType<IAddCarService, AddCarService>();
            container.RegisterType<IAddCarRequestMapper, AddCarRequestMapper>();
        }
    }
}