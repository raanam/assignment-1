using BizCover.Api.Cars.Common;
using System.Web.Mvc;

namespace BizCover.Api.Cars
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
