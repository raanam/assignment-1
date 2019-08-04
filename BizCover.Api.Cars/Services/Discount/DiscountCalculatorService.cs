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

        public async Task<IDiscountCalculatorResponse> CalculateDiscount(IReadOnlyList<int> carIds)
        {
            var allCars =  await _carRepositoryCache.GetAllCars();
            var resolvedCars = allCars.Where(c => carIds.Contains(c.Id)).ToList();

            if (resolvedCars.Count != carIds.Count())
            {
                throw new HttpRequestValidationException("Invalid Ids in the input");
            }

            var totalDiscount = _discountCalculators
                .Sum(c => c.CalculateDiscount(resolvedCars));

            return new DiscountCalculatorResponse
            {
                Discount = totalDiscount,
                Cars = resolvedCars
            };
        }
    }
}