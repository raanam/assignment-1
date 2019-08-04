using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Services.PurchasePriceCalculator
{
    public interface IPurchasePriceCalculatorService
    {
        Task<IPurchasePriceResponse> CalculatePurchasePrice(IReadOnlyList<int> carIds);
    }
}
