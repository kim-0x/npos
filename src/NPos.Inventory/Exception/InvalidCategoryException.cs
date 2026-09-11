namespace NPos.Inventory.Exception
{
    using System;
    using NPos.Inventory.Model;

    public class InvalidCategoryException : Exception
    {
        public InvalidCategoryException(string category) 
            : base($"Invalid category: '{category}'") 
        { 
        }

        public InvalidCategoryException(ProductCategory? category)
            : base((category is null) ? "Category is null exception." : $"Invalid category: '{category.Value}'")
        {
        }

        public InvalidCategoryException(string category, Exception exception)
            : base($"Invalid category: '{category}'", exception)
        {
        }
    }
}
