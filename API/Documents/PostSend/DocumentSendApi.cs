using PandaDocDotNetSDK.Models;
using Flurl;

namespace PandaDocDotNetSDK.API
{

    // documentation
    //  https://developers.pandadoc.com/reference/send-document

    // reference
    //  https://openapi.pandadoc.com/#/schemas/DocumentSendRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentSendResponse

    public class DocumentSendApi : PandaDocApi
    {

        public DocumentSendRequest Request { get; set; } = new DocumentSendRequest();

        public PandaDocHttpResponse<DocumentSendResponse> HttpResponse { get; set; } = new PandaDocHttpResponse<DocumentSendResponse>();

        public DocumentSendResponse? Response
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

        protected override bool ValidApiInput()
        {

            List<string> errors = new List<string>();

            // validate Client
            if (Client == null)
            {
                errors.Add("Client Object IS NULL/Empty");
            }

            // validate Request
            if (Request == null)
            {
                errors.Add("Request Object IS NULL/Empty");
            }
            else // (Request != null)
            {

                //
                // Validaate Request parameters...
                //

                if (string.IsNullOrEmpty(Request.Subject))
                {
                    errors.Add("Required Notification Subject IS NULL/Empty");
                }

                if (string.IsNullOrEmpty(Request.Message))
                {
                    errors.Add("Required Message Subject IS NULL/Empty");
                }

            } // (Request != null)

            if (errors.Count > 0)
            {
                throw new ArgumentOutOfRangeException(string.Join("\r\n", errors));
            }

            return true;

        } // ValidApiInput

        public void DocumentSend(string uuid)
        {

            // Validate Input based on Api Requirements
            if (!ValidApiInput())
            {
                return;
            }

            // Execute Api Call
            using (Task<PandaDocHttpResponse<DocumentSendResponse>>? task = ExecuteApi(uuid))
            {
                if ((task != null) && (task.Result != null))
                {
                    HttpResponse = task.Result;
                }
            }

        } // SendDocument

        private async Task<PandaDocHttpResponse<DocumentSendResponse>>? ExecuteApi(string uuid)
        {

            // Format Post Body
            using (HttpContent httpContent = new ObjectContent<DocumentSendRequest>(Request, Client.JsonFormatter, Request.ContentType))
            {

                // Customize Headers to Api Requirements
                httpContent.Headers.ContentType = Request.ContentType;

                // Setup "Base" Url
                Url endpointUrl = new Url(Url.Combine(Client.Settings.StrApiDocuments, uuid, "send"));

                // POST
                using (HttpResponseMessage httpResponse = await Client.HttpClient.PostAsync(endpointUrl, httpContent).ConfigureAwait(false))
                {
                    return await httpResponse.ToPandaDocResponseAsync<DocumentSendResponse>(Client.JsonFormatters)!;
                }

            } // using httpContent

        } // ExecuteApi

        public DocumentSendApi(PandaDocHttpClient client) : base(client)
        {
        }

    } // DocumentSendApi

} // namespace

