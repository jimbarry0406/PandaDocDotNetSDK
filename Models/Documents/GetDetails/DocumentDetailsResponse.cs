using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/document-details

    // reference
    //  https://openapi.pandadoc.com/#/operations/detailsDocument

    public class DocumentDetailsResponse : PandaDocResponse
    {

        // id string
        [JsonProperty("id")]
        public string? Id { get; set; }

        // name string
        [JsonProperty("name")]
        public string? Name { get; set; }

        // status string
        [JsonProperty("status")]
        public string? Status { get; set; }

        // autonumbering_sequence_name_prefix string
        [JsonProperty("autonumbering_sequence_name_prefix")]
        public string? AutoNumberingSequenceNamePrefix { get; set; }

        // date_created string
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        // date_modified string
        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        // date_completed string or null
        [JsonProperty("date_completed")]
        public DateTime? DateCompleted { get; set; }

        // created_by object
        [JsonProperty("created_by")]
        public CreatedBy? CreatedBy { get; set; }

        // template object
        [JsonProperty("template")]
        public Template? Template { get; set; }

        // expiration_date string or null
        [JsonProperty("expiration_date")]
        public DateTime? ExpirationDate { get; set; }

        // metadata object (or null)
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; } = new Dictionary<string, string>();

        // fields array[object]
        [JsonProperty("fields")]
        public Field[]? Fields { get; set; }

        // pricing object
        [JsonProperty("pricing")]
        public CreatedBy? Pricing { get; set; }

        // version string
        [JsonProperty("version")]
        public string? Version { get; set; }

        // tags array[string]
        [JsonProperty("tags")]
        public string[]? Tags { get; set; }

        // sent_by object
        [JsonProperty("sent_by")]
        public SentBy? SentBy { get; set; }

        // recipients array[object]
        [JsonProperty("recipients")]
        public DocumentRecipient[]? Recipients { get; set; }

        // grand_total object
        [JsonProperty("grand_total")]
        public GrandTotal? GrandTotal { get; set; }

        // linked_objects array[object]
        [JsonProperty("linked_objects")]
        public JsonCollection<LinkedObject> LinkedObjects { get; set; } = new JsonCollection<LinkedObject>();

        public DocumentDetailsResponse() : base()
        {

        }

    } // class DocumentDetailsResponse

} // namespace