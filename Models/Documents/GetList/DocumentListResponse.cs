using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/list-documents

    // reference
    //  https://openapi.pandadoc.com/#/operations/listDocuments

    public class DocumentListResponse : PandaDocResponse
    {

        // results array[object]
        [JsonProperty("results")]
        public Document[]? Documents { get; set; }

        public DocumentListResponse() : base()
        {

        }

    } // class DocumentListResponse

} // namespace
