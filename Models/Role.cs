using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class Role
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Role(
            [JsonProperty("name")] string? name = null,
            [JsonProperty("signing_order")] string? signingOrder = null,
            [JsonProperty("preassigned_person")] Contact? preassignedPerson = null,
            [JsonProperty("id")] string? id = null
        ) : base()
        {
            Name = name;
            SigningOrder = signingOrder;
            PreassignedPerson = preassignedPerson;
            Id = id;
        }

        public Role(Role role) : base()
        {
            Name = role.Name;
            SigningOrder = role.SigningOrder;
            PreassignedPerson = role.PreassignedPerson;
            Id = role.Id;
        }

        //
        // Read-Write Attributes
        //

        // name string
        [JsonProperty("name")]
        public string? Name { get; set; }

        // signing_order string
        [JsonProperty("signing_order")]
        public string? SigningOrder { get; set; }

        // preassigned_person object
        [JsonProperty("preassigned_person")]
        public Contact? PreassignedPerson { get; set; }

        // id string
        [JsonProperty("id")]
        public string? Id { get; set; }

    } // class Role

} // namespace PandaDocDotNetSDK.Models
