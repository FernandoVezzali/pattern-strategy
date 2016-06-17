using System.Collections.Generic;
using System.Web.Mvc;
using App.Domain;
using App.Web.Models;

namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var orders = new List<OrderViewModel>();

            orders.Add(new OrderViewModel()
            {
                OriginContactName = "Homer Simpson",
                DestinationContactName = "John Smith",
                ShippingMethod = ShippingOptions.FedEx.ToString(),
                Cost = new ShippingCalculator().CalculateCost(new Order(ShippingOptions.FedEx))
            });

            orders.Add(new OrderViewModel()
            {
                OriginContactName = "Homer Simpson",
                DestinationContactName = "John Smith",
                ShippingMethod = ShippingOptions.UPS.ToString(),
                Cost = new ShippingCalculator().CalculateCost(new Order(ShippingOptions.UPS))
            });

            orders.Add(new OrderViewModel()
            {
                OriginContactName = "Homer Simpson",
                DestinationContactName = "John Smith",
                ShippingMethod = ShippingOptions.USPS.ToString(),
                Cost = new ShippingCalculator().CalculateCost(new Order(ShippingOptions.USPS))
            });

            return View(orders);
        }
    }
}