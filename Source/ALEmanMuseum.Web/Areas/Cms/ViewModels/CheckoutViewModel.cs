namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class CheckoutViewModel
    {
        public int CheckoutNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalValue { get; set; }
    }
}
