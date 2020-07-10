using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }
    }
}