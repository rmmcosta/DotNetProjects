using System.Web.Http;
using System.Web.Mvc;

namespace ProductsWebApi.Controllers
{
    public class AvailableApisController : Controller
    {
        public HttpConfiguration Configuration { get; private set; }

        public AvailableApisController(): this(GlobalConfiguration.Configuration)
        {

        }

        public AvailableApisController(HttpConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: AvailableApis
        public ActionResult Index()
        {
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }
    }
}