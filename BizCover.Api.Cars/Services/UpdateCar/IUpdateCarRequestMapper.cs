using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Services.UpdateCar
{
    public interface IUpdateCarRequestMapper
    {
        Repository.Cars.Car Map(IUpdateCarRequest updateCarRequest);
    }
}
