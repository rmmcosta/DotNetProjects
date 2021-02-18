using Microsoft.Security.Application;
using System.Web.Mvc;

namespace MyMvcMusicStore2017.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Welcome(string username)
        {
            ViewBag.Username = username==null?"John Doe":Sanitizer.GetSafeHtmlFragment(username);
            return View();
        }
    }
}