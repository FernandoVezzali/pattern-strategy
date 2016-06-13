using Strategy.Domain;
using Strategy.Web.Models;
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
            var orders = new List<OrderViewModel>();

            orders.Add(new OrderViewModel()
            {
                OriginContactName = "Homer Simpson",
                DestinationContactName = "John Smith",
                ShippingMethod = Order.ShippingOptions.FedEx.ToString(),
                Cost = new ShippingCostCalculatorService().CalculateShippingCost(new Order() { ShippingMethod = Order.ShippingOptions.FedEx })
            });

            orders.Add(new OrderViewModel()
            {
                OriginContactName = "Homer Simpson",
                DestinationContactName = "John Smith",
                ShippingMethod = Order.ShippingOptions.UPS.ToString(),
                Cost = new ShippingCostCalculatorService().CalculateShippingCost(new Order() { ShippingMethod = Order.ShippingOptions.UPS })
            });

            orders.Add(new OrderViewModel()
            {
                OriginContactName = "Homer Simpson",
                DestinationContactName = "John Smith",
                ShippingMethod = Order.ShippingOptions.USPS.ToString(),
                Cost = new ShippingCostCalculatorService().CalculateShippingCost(new Order() { ShippingMethod = Order.ShippingOptions.USPS })
            });

            return View(orders);
        }
    }
}