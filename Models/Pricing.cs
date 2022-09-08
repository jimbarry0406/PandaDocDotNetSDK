using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class Pricing
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Pricing(
            [JsonProperty("tables")] IReadOnlyList<Table>? tables = null,
            [JsonProperty("total")] string? total = null
        ) : base()
        {
            this.Tables = tables;
            this.Total = total;
        }

        public Pricing(Pricing pricing) : base()
        {
            this.Tables = pricing.Tables;
            this.Total = pricing.Total;
        }

        //
        // Read-Write Attributes
        //

        // total string
        [JsonProperty("total")]
        public string? Total { get; set; }

        //
        // Read-Only Attributes
        //

        // tables array[object]
        [JsonProperty("tables")]
        public IReadOnlyList<Table>? Tables { get; }
//      public JsonCollection<Table>? Tables { get; } = new JsonCollection<Table>(); ???

    } // class Pricing

} // namespace
