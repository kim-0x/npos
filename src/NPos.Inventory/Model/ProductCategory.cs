using System.Globalization;

namespace NPos.Inventory.Model
{
    public class ProductCategory
    {
        private string _name = string.Empty;

        public int Id { get; set; }
        public required string Name
        {
            get => _name;
            set => _name = Capitalize(value);
        }

        private static string Capitalize(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }
    }
}
