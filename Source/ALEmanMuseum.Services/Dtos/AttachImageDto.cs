namespace ALEmanMuseum.Services.Dtos
{
    public class AttachImageDto : BaseDto
    {
        public int ImageId { get; set; }
        public int? CategoryId { get; set; }
        public int? ItemId { get; set; }

        public AttachImageDto()
        {

        }

        public AttachImageDto(string userId, int imageId, int? categoryId = null, int? itemId = null)
        {
            ImageId = imageId;
            CategoryId = categoryId;
            ItemId = itemId;
            UserId = userId;
        }
    }
}
