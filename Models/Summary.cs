using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class Summary
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Summary(
            [JsonProperty("subtotal")] string? subtotal = null,
            [JsonProperty("total")] string? total = null,
            [JsonProperty("discount")] string? discount = null,
            [JsonProperty("tax")] string? tax = null
        ) : base()
        {
            this.Subtotal = subtotal;
            this.Total = total;
            this.Discount = discount;
            this.Tax = tax;
        }

        public Summary(Summary summary) : base()
        {
            this.Subtotal = summary.Subtotal;
            this.Total = summary.Total;
            this.Discount = summary.Discount;
            this.Tax = summary.Tax;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("subtotal")]
        public string? Subtotal { get; set; }

        [JsonProperty("total")]
        public string? Total { get; set; }

        [JsonProperty("discount")]
        public string? Discount { get; set; }

        [JsonProperty("tax")]
        public string? Tax { get; set; }

    } // class Summary

} // namespace
