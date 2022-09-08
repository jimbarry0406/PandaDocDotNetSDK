using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/new-document
    //    https://developers.pandadoc.com/reference/create-document-from-pandadoc-template
    //    https://developers.pandadoc.com/reference/create-document-from-pdf

    // reference
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateByTemplateRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateByPdfRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateResponse

    public class DocumentCreateRequest : PandaDocRequest
    {

        // name string
        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }

        // template_uuid string
        [JsonProperty("template_uuid")]
        public string? TemplateUuid { get; set; }

        // folder_uuid string
        [JsonProperty("folder_uuid", NullValueHandling = NullValueHandling.Ignore)]
        public string? FolderUuid { get; set; }

        // owner object
        [JsonIgnore]
        public readonly OwnerProxy Owner = new OwnerProxy();
        //  proxy for
        [JsonProperty("owner")]
        private Dictionary<string, string>? JsonPropertyForOwner { get { return Owner.ToJsonObject(); } }

        // recipients array[object]
        [JsonProperty("recipients")]
        public JsonCollection<DocumentRecipient> Recipients { get; set; } = new JsonCollection<DocumentRecipient>();

        // tokens array[object]
        [JsonProperty("tokens")]
        public JsonCollection<Token> Tokens { get; set; } = new JsonCollection<Token>();

        // fields object (or null)
        [JsonProperty("fields")]
        public Dictionary<string, Field> Fields { get; } = new Dictionary<string, Field>();

        // metadata object (or null)
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; } = new Dictionary<string, string>();

        // tags array[string]
        [JsonProperty("tags")]
        public JsonCollection<string> Tags { get; set; } = new JsonCollection<string>();

        // content_placeholders array[object] --- NOTE: only partially implemented !!!
        [JsonProperty("content_placeholders")]
        public JsonCollection<ContentPlaceholder> ContentPlaceholders { get; set; } = new JsonCollection<ContentPlaceholder>();

        // images array[object]
        [JsonProperty("images")]
        public JsonCollection<Image> Images { get; set; } = new JsonCollection<Image>();

#pragma warning disable S1135 // Track uses of "TODO" tags

        // pricing_tables array[object] // TODO

#pragma warning restore S1135 // Track uses of "TODO" tags

        // url string
        [JsonProperty("url")]
        public string? Url { get; set; }

        // parse_form_files boolean
        [JsonProperty("parse_from_files")]
        public bool ParseFromFiles { get; set; }
        // Set this parameter as true if you create a document from a PDF with form fields and as false if you upload a PDF with field tags.

        public DocumentCreateRequest() : base()
        {
            ParseFromFiles = false;
        }

    } // class

} // namespace
