using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.Discount
{
    public class DiscountForManufacturedYear : IDiscountCalculator
    {
        public decimal CalculateDiscount(IReadOnlyList<Car> carsToPurchase)
        {
            return carsToPurchase
                .Where(c => c.Year < 2000)
                .Sum(c => c.Price * 0.10M);
        }
    }
}