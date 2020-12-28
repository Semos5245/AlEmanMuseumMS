using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class CheckoutDetailsViewModel
    {
        public int CheckoutNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalValue { get; set; }
        public IEnumerable<CheckoutItemViewModel> CheckoutItems { get; set; }
    }

    public class CheckoutItemViewModel
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ItemThumbImageName { get; set; }
    }
}
