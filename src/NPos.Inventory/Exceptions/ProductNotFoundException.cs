namespace NPos.Inventory.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(Guid productId)
            : base($"Product with ID '{productId}' not found in inventory.")
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}
