using ALEmanMuseum.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class SliderViewModel
    {
        [Required]
        [StringLength(100)]
        public string ArabicName { get; set; }

        [Required]
        [StringLength(100)]
        public string EnglishName { get; set; }
        public bool Active { get; set; }

        public int SliderId { get; set; }

        public Slider ToSliderEntity()
        {
            return new Slider
            {
                ArabicName = ArabicName,
                EnglishName = EnglishName,
                Active = Active
            };
        }
    }
}
