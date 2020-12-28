using System.Collections.Generic;

namespace ALEmanMuseum.Services.Dtos
{
    public class CreateCheckoutDto : BaseDto
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }

        public IEnumerable<CheckoutItemDto> CheckoutItems { get; set; }
    }
}
