namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class ItemDetailsDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string FullName { get; set; }
        public ItemDetailsDto() { }
    }
}
