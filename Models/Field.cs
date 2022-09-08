using Newtonsoft.Json;
using System.ComponentModel;

namespace PandaDocDotNetSDK.Models
{

    public class Field : IHasStringName, IHasObjectValue
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Field(
            [JsonProperty("name")] string? name = null,
            [JsonProperty("value")] object? value = null,
            [JsonProperty("uuid")] string? uuid = null,
            [JsonProperty("field_id")] string? fieldId = null,
            [JsonProperty("merge_field")] string? mergeField = null,
            [JsonProperty("title")] string? title = null,
            [JsonProperty("placeholder")] string? placeholder = null,
            [JsonProperty("type")] string? type = null,
            [JsonProperty("assigned_to")] AssignedTo? assignedTo = null,
            [JsonProperty("role")] string? role = null
        ) : base()
        {
            Name = name;
            if (value == null)
            {
                Value = String.Empty;
            }
            else
            {
                Value = value;
            }
            Uuid = uuid;
            FieldId = fieldId;
            MergeField = mergeField;
            Title = title;
            Placeholder = placeholder;
            Type = type;
            AssignedTo = assignedTo;
            Role = role;
        }

        public Field(Field field) : base()
        {
            Name = field.Name;
            Value = field.Value;
            Uuid = field.Uuid;
            FieldId = field.FieldId;
            MergeField = field.MergeField;
            Title = field.Title;
            Placeholder = field.Placeholder;
            Type = field.Type;
            AssignedTo = field.AssignedTo;
            Role = field.Role;
        }

        //
        // Read-Write Attributes
        //

        // name string
        [JsonProperty("name")]
        public string? Name { get; set; }

        // value string // Input/Serialize only --- does *not* work for Output/Deserialize
        // value object // Input/Serialize and Output/Deserialize
        [DefaultValue("")]
        [JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Populate)]
        public object Value { get; set; }

        // uuid string
        [JsonProperty("uuid")]
        public string? Uuid { get; set; }

        // field_id string
        [JsonProperty("field_id")]
        public string? FieldId { get; set; }

        // mergefield string
        [JsonProperty("merge_field")]
        public string? MergeField { get; set; }

        // title string
        [JsonProperty("title")]
        public string? Title { get; set; }

        // placeholder string
        [JsonProperty("placeholder")]
        public string? Placeholder { get; set; }

        // type string
        [JsonProperty("type")]
        public string? Type { get; set; }

        // assigned_to object
        [JsonProperty("assigned_to")]
        public AssignedTo? AssignedTo { get; set; }

        // role string
        [JsonProperty("role")]
        public string? Role { get; set; }

    } // class Field

} // namespace PandaDocDotNetSDK.Models
