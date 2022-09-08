using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class Token : IHasStringName, IHasObjectValue
    {

        //
        // Constructors
        //

        public Token() : base()
        {
            Name = String.Empty;
            Value = String.Empty;
        }

        [JsonConstructor]
        public Token(
            [JsonProperty("name")] string name,
            [JsonProperty("value")] object value
        ) : base()
        {
            Name = name;
            Value = value;
        }

        public Token(Token token) : base()
        {
            Name = token.Name;
            Value = token.Value;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

    } // class Token

} // namespace PandaDocDotNetSDK.Models
