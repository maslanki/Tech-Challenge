
using BusinessLib.Helpers;

namespace BusinessLib.Models
{    public class Product
    {
        public bool IsActive { get; set; }
        public List<ExtraDatum> ExtraData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Ean { get; set; }
        public string ManufacturerProductNumber { get; set; }
        public string MerchantProductNo { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double? MSRP { get; set; }
        public double? PurchasePrice { get; set; }
        public string VatRateType { get; set; }
        public double? ShippingCost { get; set; }
        public string ShippingTime { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public object ExtraImageUrl1 { get; set; }
        public object ExtraImageUrl2 { get; set; }
        public object ExtraImageUrl3 { get; set; }
        public object ExtraImageUrl4 { get; set; }
        public object ExtraImageUrl5 { get; set; }
        public object ExtraImageUrl6 { get; set; }
        public object ExtraImageUrl7 { get; set; }
        public object ExtraImageUrl8 { get; set; }
        public object ExtraImageUrl9 { get; set; }
        public string CategoryTrail { get; set; }
    }

    public class ExtraDatum
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public bool IsPublic { get; set; }
    }

    public class Root
    {
        public List<Product> Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public object RequestId { get; set; }
        public object LogId { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }
    }

    public class ValidationErrors
    {
    }



    public class ProductViewModel
    {
        public string Gtin { get; set; }
        public string ProductName { get; set; }
        public string MerchantProductNo { get; set; }
        public int TotalQuantity { get; set; }
        public override string? ToString()
        {
            return DummyStringHelper.ToString(this);
        }
    }
}
