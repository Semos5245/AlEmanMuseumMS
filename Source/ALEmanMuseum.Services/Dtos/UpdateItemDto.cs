using Microsoft.AspNetCore.Http;

namespace ALEmanMuseum.Services.Dtos
{
    public class UpdateItemDto : BaseDto
    {
        public int ItemId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public string Tags { get; set; }
        public bool Hidden { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
