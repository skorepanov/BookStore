using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookShopController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult Square(int a, int h)
        {
            // получение параметров через Request
            //int a = int.Parse(Request.Params["a"]);
            //int h = int.Parse(Request.Params["h"]);

            double s = a * h / 2.0;
            return Content( "<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s + "</h2>");
        }
    }
}