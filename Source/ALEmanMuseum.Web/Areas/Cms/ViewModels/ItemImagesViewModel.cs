using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class ItemImagesViewModel
    {
        public int? SelectedCategoryId { get; set; }
        public bool OnlyUnattached { get; set; } = true;
        public SelectList CategoriesList { get; set; }
        public SelectList ItemsList { get; set; }
        public ICollection<ItemImageViewModel> Images { get; set; }
    }
    
    public class ItemImageViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbUrl { get; set; }
        public bool Attached { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
    }
}
