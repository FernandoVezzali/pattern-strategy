using Strategy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strategy.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var order = new Order()
            {
                ShippingMethod = Order.ShippingOptions.FedEx,
                Origin = new Address() { ContactName = "John Smith" }
            };



            return View();
        }
    }
}