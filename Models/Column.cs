using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{
    public class Column
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Column(
            [JsonProperty("header")] string? header = null,
            [JsonProperty("name")] string? name = null,
            [JsonProperty("merge_name")] string? mergeName = null,
            [JsonProperty("hidden")] bool hidden = false
        ) : base()
        {
            this.Header = header;
            this.Name = name;
            this.MergeName = mergeName;
            this.Hidden = hidden;
        }

        public Column(Column column) : base()
        {
            Header = column.Header;
            Name = column.Name;
            MergeName = column.MergeName;
            Hidden = column.Hidden;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("header")]
        public string? Header { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("merge_name")]
        public string? MergeName { get; set; }

        [JsonProperty("hidden")]
        [DefaultValue(false)]
        public bool Hidden { get; set; }

    } // class Column

} // namespace
