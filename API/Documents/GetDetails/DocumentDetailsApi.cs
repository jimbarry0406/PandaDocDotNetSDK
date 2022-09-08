using PandaDocDotNetSDK.Models;
using Flurl;

namespace PandaDocDotNetSDK.API
{

    // documentation
    //  https://developers.pandadoc.com/reference/document-details

    // reference
    //  https://openapi.pandadoc.com/#/operations/detailsDocument

    public class DocumentDetailsApi : PandaDocApi
    {

        public PandaDocHttpResponse<DocumentDetailsResponse> HttpResponse { get; set; } = new PandaDocHttpResponse<DocumentDetailsResponse>();

        public DocumentDetailsResponse? Response
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

        public void GetDocumentDetails(string uuid)
        {

            // Validate Input based on Api Requirements
            if (!ValidApiInput())
            {
                return;
            }

            // Execute Api Call
            using (Task<PandaDocHttpResponse<DocumentDetailsResponse>>? task = ExecuteApi(uuid))
            {
                if ((task != null) && (task.Result != null))
                {
                    HttpResponse = task.Result;
                }
            }

        } // GetDocumentDetails


        private async Task<PandaDocHttpResponse<DocumentDetailsResponse>>? ExecuteApi(string uuid)
        {

            // Setup "Base" Url
            Url endpointUrl = new Url(Url.Combine(Client.Settings.StrApiDocuments, uuid, "details"));

            // GET
            using (HttpResponseMessage httpResponse = await Client.HttpClient.GetAsync(endpointUrl))
            {
                return await httpResponse.ToPandaDocResponseAsync<DocumentDetailsResponse>(Client.JsonFormatters)!;
            }

        } // ExecuteApi

        public DocumentDetailsApi(PandaDocHttpClient client) : base(client)
        {
        }

    } // DocumentDetailsApi

} // namespace
