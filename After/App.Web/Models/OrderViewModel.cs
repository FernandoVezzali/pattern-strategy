using System.ComponentModel;

namespace App.Web.Models
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