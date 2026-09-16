namespace NPos.Application.Dtos
{
    public record ProductDto()
    {
        public required Guid Id { get; init; }
        public required string Barcode { get; init; }
        public required string Name { get; init; }
        public required string Category { get; init; }
    }
}
