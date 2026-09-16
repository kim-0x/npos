namespace NPos.WebApi.Models
{
    public record CreateProductRequest()
    {
        public required string Barcode { get; init; }
        public required string Name { get; init; }
        public required string Category { get; init; }
    }
}
