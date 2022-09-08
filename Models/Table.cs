using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class Table
    {

        //
        // Constructors
        //
        
        [JsonConstructor]
        public Table(
            [JsonProperty("name")] string? name = null,
            [JsonProperty("id")] string? id = null,
            [JsonProperty("total")] string? total = null,
            [JsonProperty("is_included_in_total")] bool isIncludedInTotal = false,
            [JsonProperty("summary")] Summary? summary = null,
            [JsonProperty("items")] IReadOnlyList<Item>? items = null,
            [JsonProperty("currency")] string? currency = null,
            [JsonProperty("data_merge_enabled")] bool dataMergeEnabled = false,
            [JsonProperty("columns")] IReadOnlyList<Column>? columns = null
        ) : base()
        {
            this.Name = name;
            this.Id = id;
            this.Total = total;
            this.IsIncludedInTotal = isIncludedInTotal;
            this.Summary = summary;
            this.Items = items;
            this.Currency = currency;
            this.DataMergeEnabled = dataMergeEnabled;
            this.Columns = columns;
        }

        public Table(Table table) : base()
        {
            this.Name = table.Name;
            this.Id = table.Id;
            this.Total = table.Total;
            this.IsIncludedInTotal = table.IsIncludedInTotal;
            this.Summary = table.Summary;
            this.Items = table.Items;
            this.Currency = table.Currency;
            this.DataMergeEnabled = table.DataMergeEnabled;
            this.Columns = table.Columns;
        }

        //
        // Read-Write Attributes
        //

        // name string
        [JsonProperty("name")]
        public string? Name { get; set; }

        // id string
        [JsonProperty("id")]
        public string? Id { get; set; }

        // total string
        [JsonProperty("total")]
        public string? Total { get; set; }

        // is_included_in_total bool
        [JsonProperty("is_included_in_total")]
        [DefaultValue(false)]
        public bool IsIncludedInTotal { get; set; }

        // summary object
        [JsonProperty("summary")]
        public Summary? Summary { get; set; }

        // currency string
        [JsonProperty("currency")]
        public string? Currency { get; set; }

        // data_merge_enabled bool
        [JsonProperty("data_merge_enabled")]
        [DefaultValue(false)]
        public bool DataMergeEnabled { get; set; }

        //
        // Read-Only Attributes
        //

        // items array[object]
        [JsonProperty("items")]
        public IReadOnlyList<Item>? Items { get; }
//      public JsonCollection<Item>? Items { get; set; } = new JsonCollection<Item>(); ???

        // columsn array[object]
        [JsonProperty("columns")]
        public IReadOnlyList<Column>? Columns { get; }
//      public JsonCollection<Column>? Columns { get; set; } = new JsonCollection<Column>(); ???


    } // class Table

} // namespace
