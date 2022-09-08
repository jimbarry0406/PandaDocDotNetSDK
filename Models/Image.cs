using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class Image : IHasStringName
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Image(
            [JsonProperty("name")] string name,
            [JsonProperty("block_id")] string? blockId = null,
            [JsonProperty("urls")] string[]? urls = null
        ) : base()
        {
            Name = name;
            BlockId = blockId;
            Urls = urls;
        }

        public Image(Image image) : base()
        {
            Name = image.Name;
            BlockId = image.BlockId;
            Urls = image.Urls;
        }

        //
        // Read-Write Attributes
        //

        // name string
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        // block_id string
        [JsonProperty("block_id")]
        public string? BlockId { get; set; }

        // urls array[string]
        [JsonProperty("urls")]
        public string[]? Urls { get; set; }

    } // class Image

} // namespace PandaDocDotNetSDK.Models
