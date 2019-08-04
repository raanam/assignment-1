using BizCover.Api.Cars.CarRepositoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BizCover.Api.Cars.Services.Discount
{
    public class DiscountCalculatorService : IDiscountCalculatorService
    {
        private ICarRepositoryCache _carRepositoryCache;

        private IEnumerable<IDiscountCalculator> _discountCalculators;

        public DiscountCalculatorService(
            ICarRepositoryCache carRepositoryCache, 
            IEnumerable<IDiscountCalculator> discountCalculators)
        {
            _carRepositoryCache = carRepositoryCache;
            _discountCalculators = discountCalculators;
        }

        public Task<IDiscountCalculatorResponse> CalculateDiscount(IReadOnlyList<int> carIds)
        {
            throw new NotImplementedException();
        }
    }
}