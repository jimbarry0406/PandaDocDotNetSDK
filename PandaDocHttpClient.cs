using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace PandaDocDotNetSDK
{
    public sealed class PandaDocHttpClient : IDisposable
    {

        private static MediaTypeFormatterCollection _defaultJsonFormatters = new MediaTypeFormatterCollection(); // Create Default Formatters Collection that can be re-used

        public PandaDocHttpClientSettings Settings { get; set; }
        public HttpClient HttpClient { get; set; }
        public JsonMediaTypeFormatter JsonFormatter { get; set; }
        
        public MediaTypeFormatterCollection JsonFormatters
        {

            get
            {
                // Create an Empty Formatters Collection
                MediaTypeFormatterCollection activeJsonFormatters = new MediaTypeFormatterCollection();
                activeJsonFormatters.Clear();

                // Merge the Default Formatters Collection
                if (_defaultJsonFormatters.Count == 0)
                {
                    activeJsonFormatters.Add(JsonFormatter); // just use the current JsonFormatter
                }
                else // if (defaultJsonFormatters.Count > 0)
                {
                    for (int i = 0; i < _defaultJsonFormatters.Count; i++)
                    {
                        if (i == 0)
                        {
                            activeJsonFormatters.Add(JsonFormatter); // replace the current JsonFormatter (always at index zero)
                        }
                        else
                        {
                            activeJsonFormatters.Add(_defaultJsonFormatters[i]); // leave the other formatters as-is
                        }
                    }
                }

                // Return the target Collection
                return activeJsonFormatters;
            }

        } // JsonFormatters

        public PandaDocHttpClient(string strApiKey, string strApiBase = "", string strApiInstance = "")
        {
            // Settings (from input)
            Settings = new PandaDocHttpClientSettings(strApiKey, strApiBase, strApiInstance);

            // Client
            HttpClient = new HttpClient();

            // JsonFormatting
            JsonFormatter = new JsonMediaTypeFormatter();
            JsonFormatter.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            JsonFormatter.SerializerSettings.ContractResolver = JsonUtils.ShouldSerializeContractResolver.Instance; // our custom resolver, to skip empty collections by default
                                                                                                                    //    you can override this behavior by:
                                                                                                                    //      adjusting the JsonMember.Serializer settings, or
                                                                                                                    //      by adding member-specific ShouldSerialize() methods

            // Authorization
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("API-Key", Settings.StrApiKey);

            // we need to build-out a bearer-token option

        } // PandaDocHttpClient

        public void Dispose()
        {
            HttpClient.Dispose();
        }

    } // class PandaDocHttpClient

} // namespace PandaDocDotNetSDK