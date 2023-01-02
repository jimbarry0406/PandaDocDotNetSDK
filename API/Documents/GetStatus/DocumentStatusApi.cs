using PandaDocDotNetSDK.Models;
using Flurl;

namespace PandaDocDotNetSDK.API
{

    // documentation
    //  https://developers.pandadoc.com/reference/document-status

    // reference
    //  https://openapi.pandadoc.com/#/operations/DocumentStatusResponse

    public class DocumentStatusApi : PandaDocApi
    {

        public PandaDocHttpResponse<DocumentStatusResponse> HttpResponse { get; set; } = new PandaDocHttpResponse<DocumentStatusResponse>();

        public DocumentStatusResponse? Response
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

        public void DocumentStatus(string uuid)
        {

            // Validate Input based on Api Requirements
            if (!ValidApiInput())
            {
                return;
            }

            // Execute Api Call
            using (Task<PandaDocHttpResponse<DocumentStatusResponse>>? task = ExecuteApi(uuid))
            {
                if ((task != null) && (task.Result != null))
                {
                    HttpResponse = task.Result;
                }
            }

        } // DocumentStatus


        private async Task<PandaDocHttpResponse<DocumentStatusResponse>>? ExecuteApi(string uuid)
        {

            // Setup "Base" Url
            Url endpointUrl = new Url(Url.Combine(Client.Settings.StrApiDocuments, uuid));

            // GET
            using (HttpResponseMessage httpResponse = await Client.HttpClient.GetAsync(endpointUrl).ConfigureAwait(false))
            {
                return await httpResponse.ToPandaDocResponseAsync<DocumentStatusResponse>(Client.JsonFormatters)!;
            }

        } // ExecuteApi

        public DocumentStatusApi(PandaDocHttpClient client) : base(client)
        {
        }

    } // DocumentStatusApi

} // namespace
