using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class Link
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Link(
            [JsonProperty("rel")] string? rel = null,
            [JsonProperty("href")] string? href = null,
            [JsonProperty("type")] string? type = null
        ) : base()
        {
            Rel = rel;
            Href = href;
            Type = type;
        }

        public Link(Link link) : base()
        {
            Rel = link.Rel;
            Href = link.Href;
            Type = link.Type;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("rel")]
        public string? Rel { get; set; }

        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

    } // class Link

} // namespace PandaDocDotNetSDK.Models
