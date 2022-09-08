using Newtonsoft.Json;
using System;

namespace PandaDocDotNetSDK.Models
{

    public class Template
    {

        //
        // Constructors
        //

        public Template() : base()
        {
        }

        [JsonConstructor]
        public Template(
            [JsonProperty("id")] string id,
            [JsonProperty("name")] string name,
            [JsonProperty("date_created")] DateTime dateCreated,
            [JsonProperty("date_modified")] DateTime dateModified,
            [JsonProperty("version")] string version
        ) : base()
        {
            Id = id;
            Name = name;
            DateCreated = dateCreated;
            DateModified = dateModified;
            Version = version;
        }

        public Template(Template template) : base()
        {
            Id = template.Id;
            Name = template.Name;
            DateCreated = template.DateCreated;
            DateModified = template.DateModified;
            Version = template.Version;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonProperty("version")]
        public string? Version { get; set; }

    } // class Template

} // namespace
