using BizCover.Api.Cars.Services.Discount;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;

namespace BizCover.Api.Cars.Controllers
{
    public class PurchaseDiscountController : ApiController
    {
        private IDiscountCalculatorService _purchasePriceCalculatorService;

        public PurchaseDiscountController(IDiscountCalculatorService purchasePriceCalculatorService)
        {
            _purchasePriceCalculatorService = purchasePriceCalculatorService;
        }

        [System.Web.Mvc.HttpPost]
        public Task<IDiscountCalculatorResponse> Post(List<int> carIdsToPurchase)
        {
            return _purchasePriceCalculatorService.CalculateDiscount(carIdsToPurchase);
        }
    }
}