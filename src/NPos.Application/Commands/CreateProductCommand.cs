namespace NPos.Application.Commands
{
    public record CreateProductCommand()
    {
        public required string Barcode { get; init; }
        public required string Name { get; init; }
        public required string CategoryName { get; init; }
    }
}
