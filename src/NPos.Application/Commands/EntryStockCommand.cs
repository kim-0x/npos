namespace NPos.Application.Commands
{
    public record EntryStockCommand
    {
        public required string Barcode { get; init; }
        public required decimal Cost { get; init; }
        public required double Quantity { get; init; }
    }
}
