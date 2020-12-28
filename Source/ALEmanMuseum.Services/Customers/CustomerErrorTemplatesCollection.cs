using System.Collections.Generic;

namespace ALEmanMuseum.Services.Customers
{
    public abstract class CustomerErrorTemplatesCollection
    {
        protected static readonly Dictionary<CustomerErrors, string> MErrorTemplates
            = new Dictionary<CustomerErrors, string>
            {
                { CustomerErrors.CustomerNotExist, "Customer does not exist" },
                { CustomerErrors.CustomerAlreadyExist, "Customer already exist" },
                { CustomerErrors.DatabaseError, "Operation failed" }
            };

        public static string GetTemplateForError(CustomerErrors customerError)
        {
            return MErrorTemplates.GetValueOrDefault(customerError);
        }
    }
}
