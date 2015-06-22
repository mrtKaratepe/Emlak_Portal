using System.Web;
using System.Web.Mvc;

namespace Ltd.NA.Emlak.Apis
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
