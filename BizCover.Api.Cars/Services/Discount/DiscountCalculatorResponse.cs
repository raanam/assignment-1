using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.Discount
{
    public class DiscountCalculatorResponse : IDiscountCalculatorResponse
    {
        public IReadOnlyList<Car> Cars { get; set; }

        public decimal Discount { get; set; }
    }
}