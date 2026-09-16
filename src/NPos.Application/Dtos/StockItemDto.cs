namespace NPos.Application.Dtos
{
    public record StockItemDto
    {
        public required Guid Id { get; init; }
        public required Guid ProductId { get; init; }
        public required string Barcode { get; init; }
        public required decimal Cost { get; init; }
        public required double NumberInStock { get; init; }
        public required DateTime CreatedAt { get; init; }
    }
}
