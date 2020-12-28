using ALEmanMuseum.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public bool Hidden { get; set; }
        public bool AddToCartEnabled { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Tags { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbUrl { get; set; }
        public int? ImageId { get; set; }
        public IFormFile ImageFile { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public SelectList Categories { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ItemViewModel()
        {

        }

        /// <summary>
        /// Constructor for initializing current object from an <see cref="Item"/>
        /// </summary>
        /// <param name="item">Item to initialize the view model with</param>
        public ItemViewModel(Item item)
        {
            ItemId = item.Id;
            ArabicName = item.ArabicName;
            EnglishName = item.EnglishName;
            ArabicDescription = item.ArabicDescription;
            EnglishDescription = item.EnglishDescription;
            Hidden = item.Hidden;
            Quantity = item.Quantity;
            OriginalPrice = item.OriginalPrice;
            SellingPrice = item.SellingPrice;
            Tags = item.Tags;
        }

        public Item ToItemEntity()
        {
            return new Item
            {
                Id = ItemId,
                ArabicName = ArabicName,
                ArabicDescription = ArabicDescription,
                EnglishDescription = EnglishDescription,
                EnglishName = EnglishName,
                Quantity = Quantity,
                Hidden = Hidden,
                CategoryId = CategoryId,
                SellingPrice = SellingPrice,
                OriginalPrice = OriginalPrice,
                Tags = Tags
            };
        }
    }
}
