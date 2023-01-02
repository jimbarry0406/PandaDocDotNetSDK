using Newtonsoft.Json;
using System;

namespace PandaDocDotNetSDK.Models
{

    public class Document
    {

        //
        // Constructors
        //

        public Document() : base()
        {
        }

        [JsonConstructor]
        public Document(
            [JsonProperty("id")] string id,
            [JsonProperty("name")] string name,
            [JsonProperty("status")] string status,
            [JsonProperty("date_created")] DateTime? dateCreated,
            [JsonProperty("date_modified")] DateTime? dateModified,
            [JsonProperty("expiration_date")] DateTime? expirationDate,
            [JsonProperty("version")] string version
        ) : base()
        {
            Id = id;
            Name = name;
            Status = status;
            DateCreated = dateCreated;
            DateModified = dateModified;
            ExpirationDate = expirationDate;
            Version = version;
        }

        public Document(Document document) : base()
        {
            Id = document.Id;
            Name = document.Name;
            Status = document.Status;
            DateCreated = document.DateCreated;
            DateModified = document.DateModified;
            ExpirationDate = document.ExpirationDate;
            Version = document.Version;
        }

        //
        // Read-Write Attributes
        //

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

    } // class Document

} // namespace
