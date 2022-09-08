using Newtonsoft.Json;
using System.ComponentModel;

namespace ConsoleTemplateApiTest
{

    public class ClientSetup
    {

        [DefaultValue("0000000000000000000000000000000000000000")]
        [JsonProperty("PandaDocApiKey", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string? PandaDocApiKey { get; set; }

        [DefaultValue("aaaaaaaaaaaaaaaaaaaaaa")]
        [JsonProperty("PandaDocNdaTemplateId", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string? PandaDocNdaTemplateId { get; set; }

        [DefaultValue("aaaaaaaaaaaaaaaaaaaaaa")]
        [JsonProperty("PandaDocQuoteTemplateId", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string? PandaDocQuoteTemplateId { get; set; }

        [DefaultValue("test.client@gmail.com")]
        [JsonProperty("PandaDocTestClientEmail", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string? PandaDocTestClientEmail { get; set; }

        [DefaultValue("user")]
        [JsonProperty("PandaDocTestRoleName", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string? PandaDocTestRoleName { get; set; }

        [DefaultValue("test.sender@gmail.com")]
        [JsonProperty("PandaDocTestSenderEmail", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string? PandaDocTestSenderEmail { get; set; }

        [DefaultValue("test.signer@gmail.com")]
        [JsonProperty("PandaDocTestSignerEmail", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string? PandaDocTestSignerEmail { get; set; }

    } // class Options

} // namespace
