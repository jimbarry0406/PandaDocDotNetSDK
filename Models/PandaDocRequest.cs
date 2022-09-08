using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PandaDocDotNetSDK.Models
{

    public class PandaDocRequest
    {

        [JsonIgnore]
        public MediaTypeHeaderValue ContentType { get; set; }

        public PandaDocRequest()
        {
            ContentType = MediaTypeHeaderValue.Parse(@"application/json");
        }

    } // class PandaDocRequest

} // namespace
