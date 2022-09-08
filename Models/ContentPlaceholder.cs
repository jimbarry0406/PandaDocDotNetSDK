using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class ContentPlaceholder
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public ContentPlaceholder(
            [JsonProperty("uuid")] string? uuid = null,
            [JsonProperty("block_id")] string? blockId = null,
            [JsonProperty("description")] string? description = null
        ) : base()
        {
            Uuid = uuid;
            Block_id = blockId;
            Description = description;
        }

        public ContentPlaceholder(ContentPlaceholder contentPlaceholder) : base()
        {
            Uuid = contentPlaceholder.Uuid;
            Block_id = contentPlaceholder.Block_id;
            Description = contentPlaceholder.Description;
        }

        //
        // Read-Write Attributes
        //

        // uuid string
        [JsonProperty("uuid")]
        public string? Uuid { get; set; }

        // block_id string
        [JsonProperty("block_id")]
        public string? Block_id { get; set; }

        // description string
        [JsonProperty("description")]
        public string? Description { get; set; }

    } // class ContentPlaceholder

} // namespace PandaDocDotNetSDK.Models
