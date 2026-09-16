namespace NPos.WebApi.Dtos
{
    public record CreateProductDto()
    {
        public required string Barcode { get; init; }
        public required string Name { get; init; }
        public required string Category { get; init; }
    }
}
