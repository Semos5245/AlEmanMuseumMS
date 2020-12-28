using System.Collections.Generic;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class CheckoutCreationViewModel
    {
        public int CheckoutNumber { get; set; }
        public IEnumerable<ItemDetailsDto> Items { get; set; }
    }
}
