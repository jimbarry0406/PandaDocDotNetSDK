using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/list-templates

    // reference
    //  https://openapi.pandadoc.com/#/operations/listTemplates

    public class TemplateListResponse : PandaDocResponse
    {

        // results array[object]
        [JsonProperty("results")]
        public Template[]? Templates { get; set; }

        public TemplateListResponse() : base()
        {

        }

    } // class TemplateListResponse

} // namespace
