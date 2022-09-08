using Newtonsoft.Json;
using System;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/new-document

    // reference
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateResponse

    public class DocumentCreateResponse : PandaDocResponse
    {

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("uuid")]
        public string? Uuid { get; set; }

        [JsonProperty("links")]
        public Link[]? Links { get; set; }

        public DocumentCreateResponse() : base()
        {

        }

    } // class DocumentCreateResponse

} // namespace
