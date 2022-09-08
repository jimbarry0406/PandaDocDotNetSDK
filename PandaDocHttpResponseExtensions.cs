using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK
{

    public static class PandaDocHttpResponseExtensions
    {

        public static async Task<PandaDocHttpResponse>? ToPandaDocResponseAsync(this HttpResponseMessage httpResponse)
        {

            if (httpResponse == null) return null!;

            string responseContent = String.Empty;
            if (httpResponse.Content != null)
            {
                responseContent = await httpResponse.Content.ReadAsStringAsync();
            }

            PandaDocHttpResponse response = new PandaDocHttpResponse
            {
                Content = responseContent,
                IsSuccessStatusCode = httpResponse.IsSuccessStatusCode,
                StatusCode = httpResponse.StatusCode,
                Headers = httpResponse.Headers,
                HttpResponse = httpResponse
            };

            if (!httpResponse.IsSuccessStatusCode)
            {
                response.ExtractContentErrors(responseContent);
            }

            return response;

        } // Task<PandaDocHttpResponse>

        public static async Task<PandaDocHttpResponse<T>>? ToPandaDocResponseAsync<T>(this HttpResponseMessage httpResponse, MediaTypeFormatterCollection? formatters = null)
        {

            if (httpResponse == null) return null!;

            string responseContent = String.Empty;
            if (httpResponse.Content != null)
            {
                responseContent = await httpResponse.Content.ReadAsStringAsync();
            }

            var response = new PandaDocHttpResponse<T>
            {
                Content = responseContent,
                IsSuccessStatusCode = httpResponse.IsSuccessStatusCode,
                StatusCode = httpResponse.StatusCode,
                Headers = httpResponse.Headers,
                HttpResponse = httpResponse
            };

            if (httpResponse.IsSuccessStatusCode)
            {
                if (formatters == null)
                {
                    response.Value = await httpResponse.Content.ReadAsAsync<T>();
                }
                else
                {
                    response.Value = await httpResponse.Content.ReadAsAsync<T>(formatters);
                }
            }
            else
            {
                response.ExtractContentErrors(responseContent);
            }

            return response;

        } // Task<PandaDocHttpResponse<T>>

    } // class

} // namespace PandaDocDotNetSDK