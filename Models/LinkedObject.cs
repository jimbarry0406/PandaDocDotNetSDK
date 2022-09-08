using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class LinkedObject
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public LinkedObject(
            [JsonProperty("id")] string? id = null,
            [JsonProperty("provider")] string? provider = null,
            [JsonProperty("entity_type")] string? entityType = null,
            [JsonProperty("entity_id")] string? entityId = null
        ) : base()
        {
            Id = id;
            Provider = provider;
            EntityType = entityType;
            EntityId = entityId;
        }

        public LinkedObject(LinkedObject linkedObject) : base()
        {
            Id = linkedObject.Id;
            Provider = linkedObject.Provider;
            EntityType = linkedObject.EntityType;
            EntityId = linkedObject.EntityId;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("provider")]
        public string? Provider { get; set; }

        [JsonProperty("entity_type")]
        public string? EntityType { get; set; }

        [JsonProperty("entity_id")]
        public string? EntityId { get; set; }

    } // class LinkedObject

} // namespace PandaDocDotNetSDK.Models
