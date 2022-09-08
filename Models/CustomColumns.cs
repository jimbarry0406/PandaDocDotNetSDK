using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class CustomColumns
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public CustomColumns(
            [JsonProperty("Images")] JsonCollection<Image>? images = null,
            [JsonProperty("Cost")] string? cost = null,
            [JsonProperty("Subtotal")] string? subtotal = null
        ) : base()
        {
            this.Images = images;
            this.Cost = cost;
            this.Subtotal = subtotal;
        }

        CustomColumns(CustomColumns customColumns) : base()
        {
            Images = customColumns.Images;
            Cost = customColumns.Cost;
            Subtotal = customColumns.Subtotal;
        }

        //
        // Read-Write Attributes
        //

        // Images object
        [JsonProperty("Images")]
        public JsonCollection<Image>? Images { get; set; }

        // Cost string
        [JsonProperty("Cost")]
        public string? Cost { get; set; }

        // Subtotal string
        [JsonProperty("Subtotal")]
        public string? Subtotal { get; set; }

    } // class CustomColumns

} // namespace
