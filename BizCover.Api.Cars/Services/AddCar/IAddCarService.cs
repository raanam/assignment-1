using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Services.AddCar
{
    public interface IAddCarService
    {
        Task<BizCover.Repository.Cars.Car> AddCar(IAddCarRequest addCarRequest);
    }
}
