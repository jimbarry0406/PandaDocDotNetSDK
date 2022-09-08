using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PandaDocDotNetSDK.Models
{

    public class Item
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Item(
            [JsonProperty("id")] string? id = null,
            [JsonProperty("sku")] string? sku = null,
            [JsonProperty("qty")] string? qty = null,
            [JsonProperty("name")] string? name = null,
            [JsonProperty("cost")] string? cost = null,
            [JsonProperty("price")] string? price = null,
            [JsonProperty("description")] string? description = null,
            [JsonProperty("custom_fields")] CustomFields? customFields = null,
            [JsonProperty("custom_columns")] CustomColumns? customColumns = null,
            [JsonProperty("discount")] Discount? discount = null,
            [JsonProperty("tax_first")] Tax? taxFirst = null,
            [JsonProperty("tax_second")] Tax? taxSecond = null,
            [JsonProperty("subtotal")] string? subtotal = null,
            [JsonProperty("options")] Options? options = null,
            [JsonProperty("sale_price")] string? salePrice = null,
            [JsonProperty("taxes")] JsonCollection<Tax>? taxes = null,
            [JsonProperty("discounts")] JsonCollection<Discount>? discounts = null,
            [JsonProperty("fees")] JsonCollection<Fee>? fees = null,
            [JsonProperty("merged_data")] Dictionary<string, string>? mergedData = null
        ) : base()
        {
            this.Id = id;
            this.Sku = sku;
            this.Qty = qty;
            this.Name = name;
            this.Cost = cost;
            this.Price = price;
            this.Description = description;
            this.CustomFields = customFields;
            this.CustomColumns = customColumns;
            this.Discount = discount;
            this.TaxFirst = taxFirst;
            this.TaxSecond = taxSecond;
            this.Subtotal = subtotal;
            this.Options = options;
            this.SalePrice = salePrice;
            this.Taxes = taxes;
            this.Discounts = discounts;
            this.Fees = fees;
            this.MergedData = mergedData;
        }

        public Item(Item item) : base()
        {
            this.Id = item.Id;
            this.Sku = item.Sku;
            this.Qty = item.Qty;
            this.Name = item.Name;
            this.Cost = item.Cost;
            this.Price = item.Price;
            this.Description = item.Description;
            this.CustomFields = item.CustomFields;
            this.CustomColumns = item.CustomColumns;
            this.Discount = item.Discount;
            this.TaxFirst = item.TaxFirst;
            this.TaxSecond = item.TaxSecond;
            this.Subtotal = item.Subtotal;
            this.Options = item.Options;
            this.SalePrice = item.SalePrice;
            this.Taxes = item.Taxes;
            this.Discounts = item.Discounts;
            this.Fees = item.Fees;
            this.MergedData = item.MergedData;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("qty")]
        public string? Qty { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("cost")]
        public string? Cost { get; set; }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        // JsonCollection<Field> or object CustomFields ???
        [JsonProperty("custom_fields")]
        public CustomFields? CustomFields { get; set; }

        // JsonCollection<Column> or object CustomColumns ???
        [JsonProperty("custom_columns")]
        public CustomColumns? CustomColumns { get; set; }

        [JsonProperty("discount")]
        public object? Discount { get; set; }

        [JsonProperty("tax_first")]
        public Tax? TaxFirst { get; set; }

        [JsonProperty("tax_second")]
        public Tax? TaxSecond { get; set; }

        [JsonProperty("subtotal")]
        public string? Subtotal { get; set; }

        [JsonProperty("options")]
        public Options? Options { get; set; }

        [JsonProperty("sale_price")]
        public string? SalePrice { get; set; }

        [JsonProperty("taxes")]
        public JsonCollection<Tax>? Taxes { get; set; }

        [JsonProperty("discounts")]
        public JsonCollection<Discount>? Discounts { get; set; }

        [JsonProperty("fees")]
        public JsonCollection<Fee>? Fees { get; set; }

        [JsonProperty("merged_data")]
        public Dictionary<string, string>? MergedData { get; set; }

    } // class Item

} // namespace
