using Flurl.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class Discount
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Discount(
            [JsonProperty("value")] string? value = null,
            [JsonProperty("type")] string? type = null
        ) : base()
        {
            this.Value = value;
            this.Type = type;
        }

        public Discount(Discount discounts) : base()
        {
            this.Value = discounts.Value;
            this.Type = discounts.Type;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

    } // class Discounts

} // namespace
