using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcMusicStore2017.Controllers
{
    public class ApiMvcController : Controller
    {
        // GET: ApiMvc
        public ActionResult Index()
        {
            return View();
        }
    }
}