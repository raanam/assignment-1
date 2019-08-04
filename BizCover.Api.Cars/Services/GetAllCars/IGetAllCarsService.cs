using System.Collections.Generic;
using System.Threading.Tasks;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.GetAllCars
{
    public interface IGetAllCarsService
    {
        Task<IReadOnlyList<Car>> GetAllCars();
    }
}