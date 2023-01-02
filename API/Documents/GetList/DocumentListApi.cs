using PandaDocDotNetSDK.Models;
using Flurl;

namespace PandaDocDotNetSDK.API
{

    // documentation
    //  https://developers.pandadoc.com/reference/list-documents

    // reference
    //  https://openapi.pandadoc.com/#/operations/listDocuments

    public class DocumentListApi : PandaDocApi
    {

        public DocumentListUrlQueryParams UrlQueryParms { get; set; } = new DocumentListUrlQueryParams();

        public PandaDocHttpResponse<DocumentListResponse> HttpResponse { get; set; } = new PandaDocHttpResponse<DocumentListResponse>();

        public DocumentListResponse? Response
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

        public void GetDocumentList()
        {

            // Validate Input based on Api Requirements
            if (!ValidApiInput())
            {
                return;
            }

            // Execute Api Call
            using (Task<PandaDocHttpResponse<DocumentListResponse>>? task = ExecuteApi())
            {
                if ((task != null) && (task.Result != null))
                {
                    HttpResponse = task.Result;
                }
            }

        } // GetDocumentList

        private async Task<PandaDocHttpResponse<DocumentListResponse>>? ExecuteApi()
        {

            // Setup "Base" Url
            Url endpointUrl = new Url(Client.Settings.StrApiDocuments);

            // Add any input query parameters (if any)
            if ((UrlQueryParms != null) && (UrlQueryParms.ParameterCount > 0))
            {
                UrlQueryParms.CloneQueryParamsToUrl(ref endpointUrl);
            }

            // GET
            using (HttpResponseMessage httpResponse = await Client.HttpClient.GetAsync(endpointUrl).ConfigureAwait(false))
            {
                return await httpResponse.ToPandaDocResponseAsync<DocumentListResponse>(Client.JsonFormatters)!;
            }

        } // CallGetDocumentList

        public DocumentListApi(PandaDocHttpClient client) : base(client)
        {
        }

    } // DocumentListApi

} // namespace
