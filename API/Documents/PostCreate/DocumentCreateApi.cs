using PandaDocDotNetCoreSDK;
using PandaDocDotNetSDK;
using PandaDocDotNetSDK.Models;
using System.Text;
using Flurl;

namespace PandaDocDotNetSDK.API
{

    // documentation
    //  https://developers.pandadoc.com/reference/new-document
    //    https://developers.pandadoc.com/reference/create-document-from-pandadoc-template
    //    https://developers.pandadoc.com/reference/create-document-from-pdf

    // reference
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateByTemplateRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateByPdfRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateRequest
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateResponse

    public class DocumentCreateApi : PandaDocApi
    {

        public DocumentCreateUrlQueryParams UrlQueryParms { get; set; } = new DocumentCreateUrlQueryParams();

        public DocumentCreateRequest Request { get; set; } = new DocumentCreateRequest();

        public PandaDocHttpResponse<DocumentCreateResponse> HttpResponse { get; set; } = new PandaDocHttpResponse<DocumentCreateResponse>();

        public DocumentCreateResponse? Response
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

#pragma warning disable IDE0060 // Remove unused parameter, future-use
        protected bool ValidApiInput(DocumentCreateMethod method, string strFilePath = "", string strMimeType = "")
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

                // Common Validation for all Methods
                if (string.IsNullOrEmpty(Request.Name))
                {
                    errors.Add("Required Name IS NULL/Empty");
                }
                if ((Request.Recipients == null) || (Request.Recipients.Count == 0))
                {
                    errors.Add("Required Recipients Collection IS NULL/Empty");
                }

                // Method Specific Validations (if any)
                if (CreateMethod == DocumentCreateMethod.FromTemplate)
                {
                    if (string.IsNullOrEmpty(Request.TemplateUuid))
                    {
                        errors.Add("Required TemplateUuid IS NULL/Empty");
                    }
                }
                else if (CreateMethod == DocumentCreateMethod.FromLocalFile)
                {
                    if (string.IsNullOrEmpty(strFilePath))
                    {
                        errors.Add("Required File Path IS NULL/Empty");
                    }
                    if (!string.IsNullOrEmpty(strFilePath) && !File.Exists(strFilePath))
                    {
                        errors.Add("Required File Path was NOT Found:" +  strFilePath);
                    }
                }
                else if (CreateMethod == DocumentCreateMethod.FromUrlFile)
                {
                    if (string.IsNullOrEmpty(strFilePath))
                    {
                        errors.Add("Required File Url IS NULL/Empty");
                    }
                }

            } // (Request != null)

            if (errors.Count > 0)
            {
                throw new ArgumentOutOfRangeException(string.Join("\r\n", errors));
            }

            return true;

        } // ValidApiInput
#pragma warning restore IDE0060 // Remove unused parameter, future-use

        public void DocumentCreate(string strFilePath = "", string strMimeType = "")
        {

            // Validate Input based on Api Requirements
            if (!ValidApiInput(CreateMethod, strFilePath, strMimeType))
            {
                return;
            }

            // Execute Api (based on Method)
            Task<PandaDocHttpResponse<DocumentCreateResponse>>? task = null;

            // Attempt Task Work...
            try
            {

                // Instantiate Appropriate Task (based on Method)
                if (CreateMethod == DocumentCreateMethod.FromTemplate)
                {
                    task = ExecuteDocumentFromTemplateApi();
                }
                else if (CreateMethod == DocumentCreateMethod.FromLocalFile)
                {
                    task = ExecuteDocumentFromLocalFileApi(strFilePath, strMimeType);
                }
                else if (CreateMethod == DocumentCreateMethod.FromUrlFile)
                {
                    task = ExecuteDocumenetFromLocalUrlApi(strFilePath);
                }
                else
                {
                    throw new NotImplementedException("Invalid DocumentCreateMethod:" + ApiUtils.ConvertDocumentCreateMethodToString(CreateMethod));
                }

                // Validate Instantiated Task
                if ((task != null) && (task.Result != null))
                {
                    HttpResponse = task.Result;
                }

            }
            finally
            {
                if (task != null)
                {
                    try
                    {
                        task.Dispose();
                        task = null;
                    }
                    catch
                    {
                        // best efforts on manual task cleanup
                    }
                }
            }

        } // CreateDocument

        private async Task<PandaDocHttpResponse<DocumentCreateResponse>>? ExecuteDocumentFromTemplateApi()
        {

            // Format Request Content
            using (HttpContent httpContent = new ObjectContent<DocumentCreateRequest>(Request, Client.JsonFormatter, Request.ContentType))
            {

                // Customize Headers to Api Requirements
                httpContent.Headers.ContentType = Request.ContentType;

                // Setup "Base" Url
                Url endpointUrl = new Url(Client.Settings.StrApiDocuments);

                // Add any input query parameters (if any)
                if ((UrlQueryParms != null) && (UrlQueryParms.ParameterCount > 0))
                {
                    UrlQueryParms.CloneQueryParamsToUrl(ref endpointUrl);
                }

                // POST
                using (HttpResponseMessage httpResponse = await Client.HttpClient.PostAsync(endpointUrl, httpContent))
                {
                    return await httpResponse.ToPandaDocResponseAsync<DocumentCreateResponse>(Client.JsonFormatters)!;
                }

            } // using httpContent

        } // ExecuteDocumentFromTemplateApi

#pragma warning disable S4457 // Parameter validation in "async"/"await" methods should be wrapped
        private async Task<PandaDocHttpResponse<DocumentCreateResponse>>? ExecuteDocumentFromLocalFileApi(string filePath, string mimeType = "")
        {

            // Validate Input
            if (Request == null)
            {
                throw new ArgumentException("Request is null");
            }
            else if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Filename is Empty");
            }
            else if (!File.Exists(filePath))
            {
                throw new ArgumentException("Filename does not exist: " + filePath);
            }
            else // Valid Input
            {

                // Validate Temp Filename
                string strTempFilename = Path.GetRandomFileName(); // Path.GetTempFileName() = Insecure
                if (!string.IsNullOrEmpty(strTempFilename))
                {

                    // Attempt to Copy File (to avoid read/write locks)
                    try
                    {
                        File.Copy(filePath, strTempFilename);
                    }
                    catch
                    {
                        strTempFilename = filePath;
                    }

                    // Double-Check
                    if (string.IsNullOrEmpty(strTempFilename))
                    {
                        throw new ArgumentException("Temporary Filename is Empty");
                    }
                    else if (!File.Exists(strTempFilename))
                    {
                        throw new ArgumentException("Temporary Filename does not exist: " + strTempFilename);
                    }
                    else // Valid File
                    {

                        // Format Request Content
                        using (HttpContent httpContent = new ObjectContent<DocumentCreateRequest>(Request, Client.JsonFormatter, Request.ContentType))
                        {

                            if (httpContent != null)
                            {

                                // Get Request Data
                                string strRequestData = String.Empty;
                                using (Task<string> formatRequestTask = httpContent.ReadAsStringAsync())
                                {
                                    if (formatRequestTask != null)
                                    {
                                        try
                                        {
                                            strRequestData = formatRequestTask.Result;
                                        }
                                        catch
                                        {
                                            strRequestData = String.Empty;
                                        }
                                    }
                                }

                                // Validate Request Data
                                if (!string.IsNullOrEmpty(strRequestData))
                                {

                                    // Create MultiPart Content
                                    using (MultipartFormDataContent multiPartContent = new MultipartFormDataContent())
                                    {

                                        if (multiPartContent != null)
                                        {

                                            // add API method parameters as our "Data"
                                            multiPartContent.Add(new StringContent(strRequestData, Encoding.UTF8, @"application/json"), "data");

                                            //
                                            // add test file as our "File"...
                                            //

                                            // Open File
                                            using (FileStream fs = new FileStream(strTempFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                                            {

                                                if (fs != null)
                                                {

                                                    using (StreamContent streamContent = new StreamContent(fs))
                                                    {

                                                        if (streamContent != null)
                                                        {

                                                            // Get File Btyes
                                                            byte[]? bytes = null;
                                                            using (Task<byte[]> getBytesTask = streamContent.ReadAsByteArrayAsync())
                                                            {
                                                                if (getBytesTask != null)
                                                                {
                                                                    try
                                                                    {
                                                                        bytes = getBytesTask.Result;
                                                                    }
                                                                    catch
                                                                    {
                                                                        bytes = null;
                                                                    }
                                                                }
                                                            }

                                                            // Check File Bytes
                                                            if ((bytes == null) || (bytes.Length < 1))
                                                            {
                                                                throw new ArgumentException("File Btyes is null");
                                                            }
                                                            else // if ((bytes != null) && (bytes.Length > 0))
                                                            {

                                                                using (ByteArrayContent byteArrayContent = new ByteArrayContent(bytes))
                                                                {

                                                                    if (byteArrayContent != null)
                                                                    {

                                                                        // Add File Content-Type to Header
                                                                        if (byteArrayContent.Headers != null)
                                                                        {
                                                                            if (string.IsNullOrEmpty(mimeType))
                                                                            {
                                                                                mimeType = CoreApiUtils.GetMimeType(strTempFilename);

                                                                            }

                                                                            if (!string.IsNullOrEmpty(mimeType))
                                                                            {
                                                                                byteArrayContent.Headers.Add("Content-Type", mimeType);
                                                                            }
                                                                        }

                                                                        // Add File to multi-part form
                                                                        multiPartContent.Add(byteArrayContent, "file", Path.GetFileName(strTempFilename));

                                                                        // Setup "Base" Url
                                                                        Url endpointUrl = new Url(Client.Settings.StrApiDocuments);

                                                                        // Add any input query parameters (if any)
                                                                        if ((UrlQueryParms != null) && (UrlQueryParms.ParameterCount > 0))
                                                                        {
                                                                            UrlQueryParms.CloneQueryParamsToUrl(ref endpointUrl);
                                                                        }

                                                                        // POST
                                                                        using (HttpResponseMessage httpResponse = await Client.HttpClient.PostAsync(endpointUrl, multiPartContent))
                                                                        {
                                                                            if (httpResponse != null)
                                                                            {
                                                                                return await httpResponse.ToPandaDocResponseAsync<DocumentCreateResponse>(Client.JsonFormatters)!;
                                                                            }
                                                                        }

                                                                    } // byteArrayConten != null

                                                                } // using byteArrayContent

                                                            } // bytes != null

                                                        } // steamContent != null

                                                    } // using streamContent

                                                } // fs != null

                                            } // using fs

                                        } // multiPartContent != null

                                    } // using multiPartContent

                                } // strRequestData != null

                            } // httpContent != null

                        } // using httpContent

                    } // Valid File

                } // Valid Temp Filename

            } // Valid Input

            return null!;

        } // ExecuteDocumentFromLocalFileApi
#pragma warning restore S4457 // Parameter validation in "async"/"await" methods should be wrapped

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task<PandaDocHttpResponse<DocumentCreateResponse>>? ExecuteDocumenetFromLocalUrlApi(string filePath)
        {

            throw new NotImplementedException("ExecuteLocalUrlApi has not yet been Implemented");

        } // ExecuteDocumenetFromLocalUrlApi
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        private DocumentCreateMethod CreateMethod { get; set; }

        public DocumentCreateApi(PandaDocHttpClient client, DocumentCreateMethod method) : base(client)
        {
            CreateMethod = method;
        }

    } // DocumentCreateApi

} // namespace
