using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.Discount
{
    public class DiscountForCost : IDiscountCalculator
    {
        public decimal CalculateDiscount(IReadOnlyList<Car> carsToPurchase)
        {
            return carsToPurchase
                .Where(c => c.Price > 100000)
                .Sum(c => c.Price * 0.05M);
        }
    }
}