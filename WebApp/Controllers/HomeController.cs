using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {

            return View();
        }

        public ViewResult Property()
        {
            return View();
        }

        public ViewResult ExtensionMethod()
        {
            return View();
        }

        public ViewResult FilterByName()
        {
            return View();
        }

        public ViewResult Filter()
        {
            return View();
        }
    }
}
