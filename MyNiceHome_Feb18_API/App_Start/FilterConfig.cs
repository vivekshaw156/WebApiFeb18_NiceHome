using System.Web;
using System.Web.Mvc;

namespace MyNiceHome_Feb18_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
