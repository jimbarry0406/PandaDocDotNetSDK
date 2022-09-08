using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class Tax
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Tax(
            [JsonProperty("value")] string? value = null,
            [JsonProperty("type")] string? type = null
        ) : base()
        {
            this.Value = value;
            this.Type = type;
        }

        public Tax(Tax tax) : base()
        {
            this.Value = tax.Value;
            this.Type = tax.Type;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        //
        // Read-Only Attributes
        //

    } // class Tax

} // namespace
