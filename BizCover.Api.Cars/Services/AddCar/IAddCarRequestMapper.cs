using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Services.AddCar
{
    public interface IAddCarRequestMapper
    {
        Repository.Cars.Car Map(IAddCarRequest request); 
    }
}
