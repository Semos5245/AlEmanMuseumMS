using ALEmanMuseum.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class CategoryVieModel
    {
        [Required]
        [StringLength(100)]
        public string ArabicName { get; set; }

        [Required]
        [StringLength(100)]
        public string EnglishName { get; set; }

        public int CategoryId { get; set; }

        #region Helper Methods

        public Category ToCategoryEntity()
        {
            return new Category
            {
                ArabicName = ArabicName,
                EnglishName = EnglishName
            };
        }

        #endregion
    }
}
