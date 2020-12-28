namespace ALEmanMuseum.Services.Checkouts
{
    public enum CheckoutErrors
    {
        CheckoutNotExist = 1,
        EmptyCheckout = 2,
        EmptyCustomerDetails = 3,
        ItemNotExist = 4,
        NotEnoughQuantity = 5,
        PriceError = 6,
        DatabaseError = 7,
    }
}
