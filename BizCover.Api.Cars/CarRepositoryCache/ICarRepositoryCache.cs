using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.CarRepositoryCache
{
    public interface ICarRepositoryCache
    {
        Task<IReadOnlyList<Repository.Cars.Car>> GetAllCars();

        void InvalidateCache();
    }
}
