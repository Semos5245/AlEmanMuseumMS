using Microsoft.AspNetCore.Http;

namespace ALEmanMuseum.Services.Dtos
{
    public class AddItemImageDto : BaseDto
    {
        public int? CategoryId { get; set; }
        public int? ItemId { get; set; }
        public IFormFile ImageFile { get; set; }

        public AddItemImageDto()
        {

        }

        public AddItemImageDto
            (IFormFile imageFile, 
             string userId, 
             int? categoryId = null, 
             int? itemId = null)
        {
            CategoryId = categoryId;
            ItemId = itemId;
            ImageFile = imageFile;
            UserId = userId;
        }
    }
}
