using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class AssignedTo : Receipient
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public AssignedTo(
            [JsonProperty("id")] string? id = null,
            [JsonProperty("name")] string? name = null,
            [JsonProperty("preassigned_person")] Contact? preassignedPerson = null,
            [JsonProperty("role")] string? role = null,
            [JsonProperty("signing_order")] string? signingOrder = null,
            [JsonProperty("type")] string? type = null
        ) : base(email: null, type: type)
        {
            // this AssignedTo class
            Name = name;
            PreassignedPerson = preassignedPerson;
            Role = role;
            SigningOrder = signingOrder;

            // base Contact class
            Id = id;
            Type = type;
        }

        public AssignedTo(AssignedTo assignedTo) : base(assignedTo)
        {
            // this AssignedTo class
            Name = assignedTo.Name;
            PreassignedPerson = assignedTo.PreassignedPerson;
            Role = assignedTo.Role;
            SigningOrder = assignedTo.SigningOrder;

            // base Contact class
            Id = assignedTo.Id;
            Type = assignedTo.Type;
        }

        //
        // Read-Write Attributes
        //

        // id string --- already in base class
        //[JsonProperty("id")]
        //public string Id { get; set; }

        // name string
        [JsonProperty("name")]
        public string? Name { get; set; }

        // preassigned_person object
        [JsonProperty("preassigned_person")]
        public Contact? PreassignedPerson { get; set; }

        // role string
        [JsonProperty("role")]
        public string? Role { get; set; }

        // signing_order string
        [JsonProperty("signing_order")]
        public string? SigningOrder { get; set; }

        // type string --- already in base class
        //[JsonProperty("type")]
        //public string? Type { get; }

    } // class AssignedTo

} // namespace PandaDocDotNetSDK.Models
