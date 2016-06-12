using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using static Strategy.Domain.Order;

namespace Strategy.Web.Models
{
    public class OrderViewModel
    {
        [DisplayName("Destination")]
        public string DestinationContactName { get; set; }

        [DisplayName("Origin")]
        public string OriginContactName { get; set; }

        [DisplayName("Shipping Method")]
        public string ShippingMethod { get; set; }

        public double Cost { get; set; }
    }
}