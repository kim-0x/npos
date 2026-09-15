namespace NPos.Inventory.Model
{
    public class Product : IComparable<Product>
    {
        public Guid Id { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public required ProductCategory Category { get; set; }
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
