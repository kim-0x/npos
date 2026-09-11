namespace NPos.Inventory.Exception
{
    using System;
    public class InvalidCategoryException : Exception
    {
        public InvalidCategoryException(string category) 
            : base($"Invalid category: '{category}'") 
        { 
        }

        public InvalidCategoryException(string category, Exception exception)
            : base($"Invalid category: '{category}'", exception)
        {
        }
    }
}
