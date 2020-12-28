using System.Collections.Generic;

namespace ALEmanMuseum.Services.Checkouts
{
    public abstract class CheckoutErrorTemplatesCollection
    {
        private static readonly Dictionary<CheckoutErrors, string> MErrorTemplates
            = new Dictionary<CheckoutErrors, string>()
            {
                { CheckoutErrors.CheckoutNotExist, "Checkout does not exist" },
                { CheckoutErrors.EmptyCheckout, "Checkout is empty" },
                { CheckoutErrors.EmptyCustomerDetails, "Customer details are not valid" },
                { CheckoutErrors.ItemNotExist, "Can't add an item that doesn't exist" },
                { CheckoutErrors.NotEnoughQuantity, "Not enough quantity of {0}" },
                { CheckoutErrors.PriceError, "Invalid price for item {0}" },
                { CheckoutErrors.DatabaseError, "Operation failed" }
            };

        public static string GetTemplateForError(CheckoutErrors error)
            => MErrorTemplates.GetValueOrDefault(error);
    }
}
