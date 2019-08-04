using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.Discount
{
    public class DiscountForQuantity : IDiscountCalculator
    {
        public decimal CalculateDiscount(IReadOnlyList<Car> carsToPurchase)
        {
            return carsToPurchase.Count() > 2 ? carsToPurchase.Sum(c => c.Price * 0.03M) : 0M;
        }
    }
}