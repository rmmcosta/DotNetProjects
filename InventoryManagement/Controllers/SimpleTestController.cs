using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class SimpleTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnotherOne()
        {
            return View();
        }
    }
}