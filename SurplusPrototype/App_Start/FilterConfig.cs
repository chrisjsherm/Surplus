using System.Web;
using System.Web.Mvc;

namespace SurplusPrototype
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Force requests into role authorization pipeline.
            //if (!HttpContext.Current.IsDebuggingEnabled)
            //{
            //    filters.Add(new AuthorizeAttribute());
            //}
        }
    }
}
