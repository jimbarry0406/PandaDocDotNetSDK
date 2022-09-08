using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/template-details

    // reference
    //  https://openapi.pandadoc.com/#/operations/detailsTemplate

    public class TemplateDetailsResponse : PandaDocResponse
    {

        // id string
        [JsonProperty("id")]
        public string? Id { get; set; }

        // name string
        [JsonProperty("name")]
        public string? Name { get; set; }

        // version string
        [JsonProperty("version")]
        public string? Version { get; set; }

        // date_created string
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        // date_modified string
        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        // created_by object
        [JsonProperty("created_by")]
        public CreatedBy? CreatedBy { get; set; }

        // tags array[string]
        [JsonProperty("tags")]
        public string[]? Tags { get; set; }

        // metadata object (or null)
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

        // fields array[object]
        [JsonProperty("fields")]
        public Field[]? Fields { get; set; }

        // roles array[object]
        [JsonProperty("roles")]
        public Role[]? Roles { get; set; }

        // images array[object]
        [JsonProperty("images")]
        public Image[]? Images { get; set; }

        // content_placeholders array[object] --- NOTE: only partially implemented !!!
        [JsonProperty("content_placeholders")]
        public ContentPlaceholder[]? ContentPlaceholders { get; set; }

        // pricing object
        [JsonProperty("pricing")]
        public CreatedBy? Pricing { get; set; }

        public TemplateDetailsResponse() : base()
        {

        }

    } // class TemplateDetailsResponse

} // namespace