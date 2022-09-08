using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class GrandTotal
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public GrandTotal(
            [JsonProperty("amount")] string? amount = null,
            [JsonProperty("currency")] string? currency = null
        ) : base()
        {
            Amount = amount;
            Currency = currency;
        }

        public GrandTotal(GrandTotal grandTotal) : base()
        {
            Amount = grandTotal.Amount;
            Currency = grandTotal.Currency;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("amount")]
        public string? Amount { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

    } // class

} // namespace
