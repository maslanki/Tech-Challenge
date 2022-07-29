
using BusinessLib.Helpers;

namespace BusinessLib.Models
{
    public class Product
    {
        public string Gtin { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
        public override string? ToString()
        {
            return DummyStringHelper.ToString(this);
        }
    }
}
