using Newtonsoft.Json;
namespace BusinessLib.Models
{
    public partial class RequestResult
    {
        [JsonProperty("Content")]
        public Order[] Content { get; set; }

    }

    public class Order
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int GlobalChannelId { get; set; }
        public string ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime AcknowledgedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MerchantComment { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public double SubTotalInclVat { get; set; }
        public double SubTotalVat { get; set; }
        public double ShippingCostsVat { get; set; }
        public double TotalInclVat { get; set; }
        public double TotalVat { get; set; }
        public double OriginalSubTotalInclVat { get; set; }
        public double OriginalSubTotalVat { get; set; }
        public double OriginalShippingCostsInclVat { get; set; }
        public double OriginalShippingCostsVat { get; set; }
        public double OriginalTotalInclVat { get; set; }
        public double OriginalTotalVat { get; set; }
        public List<Line> Lines { get; set; }
        public double ShippingCostsInclVat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public object CompanyRegistrationNo { get; set; }
        public object VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public object PaymentReferenceNo { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public object ChannelCustomerNo { get; set; }
        public ExtraDatas ExtraData { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string Gender { get; set; }
        public string? CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public object HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public object Region { get; set; }
        public string CountryIso { get; set; }
        public object Original { get; set; }
    }

    public class StockLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ExtraDatas
    {
        [JsonProperty("Extra Data")]
        public string ExtraData { get; set; }
    }

    public class Line
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public double UnitVat { get; set; }
        public double LineTotalInclVat { get; set; }
        public double LineVat { get; set; }
        public double OriginalUnitPriceInclVat { get; set; }
        public double OriginalUnitVat { get; set; }
        public double OriginalLineTotalInclVat { get; set; }
        public double OriginalLineVat { get; set; }
        public double OriginalFeeFixed { get; set; }
        public object BundleProductMerchantProductNo { get; set; }
        public object JurisCode { get; set; }
        public object JurisName { get; set; }
        public double VatRate { get; set; }
        public List<ExtraDatas> ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public double UnitPriceInclVat { get; set; }
        public double FeeFixed { get; set; }
        public double FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
