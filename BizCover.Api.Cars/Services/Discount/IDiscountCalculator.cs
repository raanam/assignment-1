using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Services.Discount
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(IReadOnlyList<Repository.Cars.Car> carsToPurchase);
    }
}
