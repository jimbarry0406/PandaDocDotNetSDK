using PandaDocDotNetSDK.Models;
using Flurl;

namespace PandaDocDotNetSDK.API
{

    // documentation
    //  https://developers.pandadoc.com/reference/list-templates

    // reference
    //  https://openapi.pandadoc.com/#/operations/listTemplates

    public class TemplateListApi : PandaDocApi
    {

        public TemplateListUrlQueryParams UrlQueryParms { get; set; } = new TemplateListUrlQueryParams();

        public PandaDocHttpResponse<TemplateListResponse> HttpResponse { get; set; } = new PandaDocHttpResponse<TemplateListResponse>();

        public TemplateListResponse? Response
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

        public void GetTemplateList()
        {

            // Validate Input based on Api Requirements
            if (!ValidApiInput())
            {
                return;
            }

            // Execute Api Call
            using (Task<PandaDocHttpResponse<TemplateListResponse>>? task = ExecuteApi())
            {
                if ((task != null) && (task.Result != null))
                {
                    HttpResponse = task.Result;
                }
            }

        } // GetTemplateList

        private async Task<PandaDocHttpResponse<TemplateListResponse>>? ExecuteApi()
        {

            // Setup "Base" Url
            Url endpointUrl = new Url(Client.Settings.StrApiTemplates);

            // Add any input query parameters (if any)
            if ((UrlQueryParms != null) && (UrlQueryParms.ParameterCount > 0))
            {
                UrlQueryParms.CloneQueryParamsToUrl(ref endpointUrl);
            }

            // GET
            using (HttpResponseMessage httpResponse = await Client.HttpClient.GetAsync(endpointUrl))
            {
                return await httpResponse.ToPandaDocResponseAsync<TemplateListResponse>(Client.JsonFormatters)!;
            }

        } // CallGetTemplateList

        public TemplateListApi(PandaDocHttpClient client) : base(client)
        {
        }

    } // TemplateListApi

} // namespace
