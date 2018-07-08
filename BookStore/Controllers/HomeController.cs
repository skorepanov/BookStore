using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Utils;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return $"Спасибо, {purchase.Person}, за покупку!";
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет, мир!</h2>");
        }

        public ActionResult GetImage()
        {
            string path = "https://cdn.tproger.ru/wp-content/themes/bliss/assets/img/tp-circle2.png";
            return new ImageResult(path);
        }
    }
}