using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Services.PurchasePriceCalculator
{
    public interface IPurchasePriceResponse
    {
        IReadOnlyList<Repository.Cars.Car> Cars { get; }

        decimal PurchasePrice { get; }
    }
}
