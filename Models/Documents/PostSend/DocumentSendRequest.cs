using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/send-document

    // reference
    //  https://openapi.pandadoc.com/#/schemas/DocumentSendRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentSendResponse

    public class DocumentSendRequest : PandaDocRequest
    {

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("subject")]
        public string? Subject { get; set; }

        [JsonProperty("silent")]
        public bool Silent { get; set; }

        public DocumentSendRequest() : base()
        {
            Silent = false; // Send Notifications to involved Roles
        }

    } // class

} // namespace
