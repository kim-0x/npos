using NPos.Inventory.Exception;

namespace NPos.Inventory.Model
{
    public class Product : IComparable<Product>
    {
        private ProductCategory? _category;

        public Guid Id { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        
        public ProductCategory? Category 
        {
            get { return _category; }
            set
            {
                if (value is null)
                {
                    throw new InvalidCategoryException(value);
                }
                _category = value;
            }
        }
        public int CompareTo(Product? other)
        {
            if (other is null) return 1;

            bool hasMatchingId = Id.Equals(other.Id);
            bool hasMatchingBarcode = Barcode.Equals(other.Barcode, StringComparison.OrdinalIgnoreCase);

            if (hasMatchingBarcode || hasMatchingId) return 0;

            int barcodeComparison = string.Compare(Barcode, other.Barcode, StringComparison.OrdinalIgnoreCase);
            if (barcodeComparison != 0) return barcodeComparison;

            return Id.CompareTo(other.Id);
        }
    }
}
