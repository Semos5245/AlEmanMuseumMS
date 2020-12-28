using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class UploadImagesDto
    {
        public int? CategoryId { get; set; }
        public ICollection<IFormFile> ImageFiles { get; set; }
    }
}
