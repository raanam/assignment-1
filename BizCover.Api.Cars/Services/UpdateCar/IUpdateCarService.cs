using System.Threading.Tasks;

namespace BizCover.Api.Cars.Services.UpdateCar
{
    public interface IUpdateCarService
    {
        Task<Repository.Cars.Car> Update(IUpdateCarRequest updateCarRequest);
    }
}
