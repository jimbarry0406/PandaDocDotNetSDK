using Newtonsoft.Json;
using PandaDocDotNetSDK;

namespace PandaDocDotNetSDK.Models
{

    public class Metadata : IHasStringName, IHasObjectValue
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Metadata(
            [JsonProperty("tag")] string tag,
            [JsonProperty("value")] string? value = null
        )
        {
            Tag = tag;
            if (value == null)
            {
                Value = String.Empty;
            }
            else
            {
                Value = value;
            }
        }

        public Metadata(Metadata metadata)
        {
            Tag = metadata.Tag;
            Value = metadata.Value;
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("tag", Required = Required.Always)]
        public string Tag { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        //
        // Methods
        //

        public string Name { get { return Tag; } set { Tag = value; } } // Add Support for IHasStringName

    } // class Metadata

} // namespace PandaDocDotNetSDK.Models
