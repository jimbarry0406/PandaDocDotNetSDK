using PandaDocDotNetSDK.Models;
using Flurl;

namespace PandaDocDotNetSDK.API
{

    // documentation
    //  https://developers.pandadoc.com/reference/template-details

    // reference
    //  https://openapi.pandadoc.com/#/operations/detailsTemplate

    public class TemplateDetailsApi : PandaDocApi
    {

        public PandaDocHttpResponse<TemplateDetailsResponse> HttpResponse { get; set; } = new PandaDocHttpResponse<TemplateDetailsResponse>();

        public TemplateDetailsResponse? Response
        {
            get
            {
                if ((HttpResponse == null) || (HttpResponse.Value == null))
                {
                    return null;
                }
                else
                {
                    return HttpResponse.Value;
                }
            }
        }

        public void GetTemplateDetails(string uuid)
        {

            // Validate Input based on Api Requirements
            if (!ValidApiInput())
            {
                return;
            }

            // Execute Api Call
            using (Task<PandaDocHttpResponse<TemplateDetailsResponse>>? task = ExecuteApi(uuid))
            {
                if ((task != null) && (task.Result != null))
                {
                    HttpResponse = task.Result;
                }
            }

        } // GetTemplateDetails

        private async Task<PandaDocHttpResponse<TemplateDetailsResponse>>? ExecuteApi(string uuid)
        {

            // Setup "Base" Url
            Url endpointUrl = new Url(Url.Combine(Client.Settings.StrApiTemplates, uuid, "details"));

            // GET
            using (HttpResponseMessage httpResponse = await Client.HttpClient.GetAsync(endpointUrl))
            {
                return await httpResponse.ToPandaDocResponseAsync<TemplateDetailsResponse>(Client.JsonFormatters)!;
            }

        } // CallGetTemplateDetails

        public TemplateDetailsApi(PandaDocHttpClient client) : base(client)
        {
        }

    } // TemplateDetailsApi

} // namespace
