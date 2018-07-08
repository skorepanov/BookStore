﻿using System;
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
            if (id > 3)
            {
                return Redirect("/Home/Index");
            }
            
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

        #region ActionResults
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет, мир!</h2>");
        }

        public ActionResult GetImage()
        {
            string path = "https://cdn.tproger.ru/wp-content/themes/bliss/assets/img/tp-circle2.png";
            return new ImageResult(path);
        }
        #endregion ActionResults

        #region ViewResult
        public ViewResult SomeMethod()
        {
            //ViewData["Head"] = "Привет, мир!";
            ViewBag.Head = "Привет, мир!";
            return View("SomeView");
        }
        #endregion ViewResult

        #region RedirectResult
        public RedirectResult SomeRedirectMethod()
        {
            // временная переадресация
            // считается, что запрашиваемый документ временно перемещен на другую страницу.
            return Redirect("/Home/Index");

            // постоянная переадресация
            // считается, что запрашиваемый документ окончательно перемещен в другое место
            // исп-ть нежелательно, т.к. браузер может автоматически
            // настраивать запросы на новый ресурс, даже если старый ресурс
            // со временем перестанет применять переадресацию.
            //return RedirectPermanent("/Home/Index");
        }

        public RedirectToRouteResult SomeRTRMethod()
        {
            // перенаправление по определенному маршруту внутри домена
            return RedirectToRoute(
                new { controller = "Home", action = "Index" });
        }

        public RedirectToRouteResult SomeRTAMethod()
        {
            // перенаправление к определенному действию определенного контроллера
            return RedirectToAction("Square", "Home",
                new { a = 10, h = 12 });
        }

        public ActionResult CheckAge(int age)
        {
            if (age < 21)
            {
                //return new HttpStatusCodeResult(404);
                return HttpNotFound();
                //return HttpUnauthorizedResult();
            }

            return View();
        }
        #endregion RedirectResult
    }
}