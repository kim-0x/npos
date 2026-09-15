using NPos.Inventory.Model;

namespace NPos.Inventory.Exceptions
{
    public class InvalidCategoryException : Exception
    {
        public InvalidCategoryException(string category)
            : base($"Invalid category: '{category}'")
        {
        }

        public InvalidCategoryException(ProductCategory? category)
            : base((category is null) ? "Category is null exception." : $"Invalid category: '{category.Name}'")
        {
        }

        public InvalidCategoryException(string category, Exception exception)
            : base($"Invalid category: '{category}'", exception)
        {
        }
    }
}
