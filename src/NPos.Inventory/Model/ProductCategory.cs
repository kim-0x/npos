using NPos.Inventory.Exceptions;

namespace NPos.Inventory.Model
{
    public sealed class ProductCategory
    {
        public static ProductCategory FOOD => new("food");
        public static ProductCategory BEVERAGE => new("beverage");
        public static ProductCategory HOUSEHOLD => new("household");
        public static ProductCategory FRUIT => new("fruit");
        public static ProductCategory DAIRY => new("dairy");

        public string Value { get; }
        private ProductCategory(string value)
        {
            Value = value;
        }

        public static IReadOnlyCollection<ProductCategory> All { get; } =
        [
            FOOD,
            BEVERAGE,
            HOUSEHOLD,
            FRUIT,
            DAIRY
        ];

        public static ProductCategory FromString(string value)
        {
            foreach (var category in All)
            {
                if (category.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return category;
                }
            }

            throw new InvalidCategoryException(value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
