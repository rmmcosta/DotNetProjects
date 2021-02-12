using MyMvcMusicStore2017.Models;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyMvcMusicStore2017
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MusicStoreDBInitializer());       
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-PT");
        }
    }
}
