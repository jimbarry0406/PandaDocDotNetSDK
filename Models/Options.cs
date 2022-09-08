using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class Options
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Options(
            [JsonProperty("optional")] bool optional = false,
            [JsonProperty("optional_selected")] bool optionalSelected = true,
            [JsonProperty("qty_editable")] bool qtyEditable = false
        ) : base()
        {
            this.Optional = optional;
            this.OptionalSelected = optionalSelected;
            this.QtyEditable = qtyEditable;
        }

        public Options(Options options) : base()
        {
            this.Optional = options.Optional;
            this.OptionalSelected = options.OptionalSelected;
            this.QtyEditable = options.QtyEditable;
        }

        //
        // Read-Write Attributes
        //

        [DefaultValue(false)]
        [JsonProperty("optional", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool Optional { get; set; }

        [DefaultValue(true)]
        [JsonProperty("optional_selected", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool OptionalSelected { get; set; }

        [DefaultValue(false)]
        [JsonProperty("qty_editable", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool QtyEditable { get; set; }

    } // class Options

} // namespace
