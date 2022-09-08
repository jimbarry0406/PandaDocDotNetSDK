using Microsoft.Win32;
using PandaDocDotNetSDK.API;
using PandaDocDotNetSDK.Models;
using PandaDocDotNetSDK;

namespace ConsoleTemplateApiTest
{
    internal static class ClientHelpers
    {

        //
        // Test API Methods...
        //

        public static bool GetDocumentDetails(PandaDocHttpClient client, string strDocumentId)
        {

            bool bErrors = false;

            // Validate Input
            if ((client != null) && !string.IsNullOrEmpty(strDocumentId))
            {

                // Validate Api
                DocumentDetailsApi documentDetailsApi = new DocumentDetailsApi(client);
                if (documentDetailsApi != null)
                {

                    //
                    // No Request or Query Parameters...
                    //

                    // Execute Api
                    try
                    {
                        documentDetailsApi.GetDocumentDetails(strDocumentId);
                    }
                    catch (Exception ex)
                    {
                        ClientUtils.LogExceptions(ex, "GetDocumentDetails.Exception", strDocumentId);
                        bErrors = true;
                    }

                    // Evaluate Response
                    if (documentDetailsApi.HttpResponse == null)
                    {
                        ClientUtils.LogError("  HttpResonse IS NULL");
                        bErrors = true;
                    }
                    else // if (documentDetailsApi.HttpResponse is not null)
                    {

                        // Log Response Errors
                        if ((documentDetailsApi.HttpResponse.Errors != null) && (documentDetailsApi.HttpResponse.Errors.Count > 0))
                        {
                            ClientUtils.LogErrors(documentDetailsApi.HttpResponse.Errors, "  ");
                        }

                        // Log Response Status Errors
                        if (!documentDetailsApi.HttpResponse.IsSuccessStatusCode)
                        {
                            ClientUtils.LogError("Execution HttpResponse Error:" + documentDetailsApi.HttpResponse.StatusCode.ToString());
                        }

                        // Any Problems?
                        bErrors = bErrors || !documentDetailsApi.HttpResponse.IsSuccessStatusCode;

                        // Evaluate Response Class
                        if (documentDetailsApi.Response != null)
                        {

                            // Success?
                            if (bErrors)
                            {

                                // Log Details
                                ClientUtils.LogError("Error:DocumentDetails:");
                                ClientUtils.LogError("  type:" + documentDetailsApi.Response.Type);
                                ClientUtils.LogError("  detail:" + documentDetailsApi.Response.Detail);
                                ClientUtils.LogError("  Errors.Count:" + documentDetailsApi.HttpResponse.Errors?.Count.ToString());
                                ClientUtils.LogError("  IsSuccessStatusCode:" + documentDetailsApi.HttpResponse.IsSuccessStatusCode.ToString());

                            }
                            else // resonsehttp Successful
                            {

                                // Log Details
                                ClientUtils.LogError("  DocumentDetails...");
                                ClientUtils.LogError("  ==================");
                                ClientUtils.LogError("    Name:" + documentDetailsApi.Response.Name);
                                ClientUtils.LogError("    Id:" + documentDetailsApi.Response.Id);
                                ClientUtils.LogError("    Status:" + documentDetailsApi.Response.Status);
                                DateTime? created = documentDetailsApi.Response.DateCreated;
                                if (created != null)
                                {
                                    ClientUtils.LogError("    DateCreated:" + ((DateTime)created).ToString("G"));
                                }
                                ClientUtils.LogError("    Version:" + documentDetailsApi.Response.Version);

                                foreach (Token t in documentDetailsApi.Response.DefaultVariables!)
                                {
                                    ClientUtils.LogError("    test of general DefaultVariables Array:" + t.Name + "." + t.Value);
                                }

                                ClientUtils.LogError("    test of specific GetDefaultVariable Method Defaults.Document.Name:" + documentDetailsApi.Response.GetDefaultVariableString("Defaults.Document.Name"));

                            } // resonsehttp Successful

                        } // response != null

                    } // responseHttp != null

                } // templateDetailsApi != null

            } // Valid Input

            // Process Request
            return !bErrors;

        } // GetDocumentDetails

        public static string CreateDocumentFromFile(PandaDocHttpClient client)
        {

            string strDocumentId = String.Empty;
            bool bErrors = false;

            // Validate Client
            if (client != null)
            {

                // Validate Api
                DocumentCreateApi documentCreateApi = new DocumentCreateApi(client, DocumentCreateMethod.FromLocalFile);
                if (documentCreateApi != null)
                {

                    //
                    // Setup Request Parameters...
                    //

                    documentCreateApi.Request.Name = "Demo Test Document Creation";

                    //documentCreateApi.Request.Owner.Set("me@domain.com");

                    documentCreateApi.Request.Recipients.Add(
                        new DocumentRecipient(
                            email: ClientUtils.ClientSetup!.PandaDocTestSignerEmail,
                            role: ClientUtils.ClientSetup!.PandaDocTestRoleName
                        ));

                    // variables
                    //documentCreateApi.Request.Tokens.Add(new Token("Draft.Date", DateTime.Now.ToString("MM/dd/yy")));

                    // fields (assigned or unassigned)
                    //documentCreateApi.Request.Fields.Add("MergeField.Today", new Field(DateTime.Now.ToString("MM/dd/yyyy"))); // Use [second] Merge Field (Name), *not* [first] Field Id

                    // metadata
                    //documentCreateApi.Request.Metadata.Add("my_favorite_pet", "Panda");

                    // tags
                    documentCreateApi.Request.Tags.Set(new string[] { "created_via_api", "demo", "file" });

                    // This example will be using Field Tags
                    documentCreateApi.Request.ParseFromFiles = true;

                    // Get Test Filename
                    //  string strFilename = @".\test.docx";
                    //  string strFilename = @".\test.pdf";
                    string strFilename = @".\test.docx";

                    // Execute Api
                    try
                    {
                        documentCreateApi.DocumentCreate(strFilename);
                    }
                    catch (Exception ex)
                    {
                        ClientUtils.LogExceptions(ex, "DocumentCreate.Exception", strFilename);
                        bErrors = true;
                    }

                    // Evaluate Response
                    if (documentCreateApi.HttpResponse == null)
                    {
                        ClientUtils.LogError("  HttpResonse IS NULL");
                        bErrors = true;
                    }
                    else // if (documentCreateApi.HttpResponse != null)
                    {

                        // Log Response Errors
                        if ((documentCreateApi.HttpResponse.Errors != null) && (documentCreateApi.HttpResponse.Errors.Count > 0))
                        {
                            ClientUtils.LogErrors(documentCreateApi.HttpResponse.Errors, "  ");
                        }

                        // Log Response Status Errors
                        if (!documentCreateApi.HttpResponse.IsSuccessStatusCode)
                        {
                            ClientUtils.LogError("Execution HttpResponse Error:" + documentCreateApi.HttpResponse.StatusCode.ToString());
                        }

                        // Any Problems?
                        bErrors = bErrors || !documentCreateApi.HttpResponse.IsSuccessStatusCode;

                        // Evaluate Response Class
                        if (documentCreateApi.Response != null)
                        {

                            // Success?
                            if (bErrors)
                            {

                                // Log Details
                                ClientUtils.LogError("Error:CreateDocument:");
                                ClientUtils.LogError("  type:" + documentCreateApi.Response.Type);
                                ClientUtils.LogError("  detail:" + documentCreateApi.Response.Detail);
                                ClientUtils.LogError("  Errors.Count:" + documentCreateApi.HttpResponse.Errors?.Count.ToString());
                                ClientUtils.LogError("  IsSuccessStatusCode:" + documentCreateApi.HttpResponse.IsSuccessStatusCode.ToString());

                                // Clear
                                strDocumentId = String.Empty;

                            }
                            else // if (responseHttp.IsSuccessStatusCode)
                            {

                                // Log Details
                                ClientUtils.LogError("Success:CreateDocument:");
                                ClientUtils.LogError("  uuid:" + documentCreateApi.Response.Uuid);
                                ClientUtils.LogError("  status:" + documentCreateApi.Response.Status + "...");

                                // Assign DocumentId from Response
                                strDocumentId = documentCreateApi.Response.Uuid ?? String.Empty;

                            } // resonsehttp Successful

                        } // response != null

                    } // responseHttp != null

                } // documentCreateApi != null

            } // client != null

            // Final Answer
            return strDocumentId;

        } // CreateDocumentFromFile

        public static bool DocumentStatusReady(PandaDocHttpClient client, string strDocumentId)
        {

            bool bReady = false;
            bool bErrors = false;

            // Validate Input
            if ((client != null) && !string.IsNullOrEmpty(strDocumentId))
            {

                // Validate Api
                DocumentStatusApi documentStatusApi = new DocumentStatusApi(client);
                if (documentStatusApi != null)
                {

                    //
                    // No Request or Query Parameters ...
                    //

                    // Execute Api
                    try
                    {
                        documentStatusApi.DocumentStatus(strDocumentId);
                    }
                    catch (Exception ex)
                    {
                        ClientUtils.LogExceptions(ex, "DocumentStatus.Exception", strDocumentId);
                        bErrors = true;
                    }

                    // Evaluate Response
                    if (documentStatusApi.HttpResponse == null)
                    {
                        ClientUtils.LogError("  HttpResonse IS NULL");
                        bErrors = true;
                    }
                    else // if (documentStatusApi.HttpResponse is not null)
                    {

                        // Log Response Errors
                        if ((documentStatusApi.HttpResponse.Errors != null) && (documentStatusApi.HttpResponse.Errors.Count > 0))
                        {
                            ClientUtils.LogErrors(documentStatusApi.HttpResponse.Errors, "  ");
                        }

                        // Log Response Status Errors
                        if (!documentStatusApi.HttpResponse.IsSuccessStatusCode)
                        {
                            ClientUtils.LogError("Execution HttpResponse Error:" + documentStatusApi.HttpResponse.StatusCode.ToString());
                        }

                        // Any Problems?
                        bErrors = bErrors || !documentStatusApi.HttpResponse.IsSuccessStatusCode;

                        // Evaluate Response Class
                        if (documentStatusApi.Response != null)
                        {

                            string status = documentStatusApi.Response.Status ?? ApiUtils.ConvertDocumentStatusDomainToString(DocumentStatusDomain.Unknown);

                            // Success?
                            if (bErrors)
                            {

                                // Log Details
                                ClientUtils.LogError("  status:" + documentStatusApi.Response.Status);
                                ClientUtils.LogError("  type:" + documentStatusApi.Response.Type);
                                ClientUtils.LogError("  detail:" + documentStatusApi.Response.Detail);
                                ClientUtils.LogError("  Errors.Count:" + documentStatusApi.HttpResponse.Errors?.Count.ToString());
                                ClientUtils.LogError("  IsSuccessStatusCode:" + documentStatusApi.HttpResponse.IsSuccessStatusCode.ToString());

                            }
                            else // if !bErrors
                            {

                                // Log Details
                                ClientUtils.LogError(status, strPreFixPadding: "  status:", bCrLf: false);

                                // Look for "Ready" Status (Draft)
                                if (
                                        (documentStatusApi.Response != null)
                                    &&  (documentStatusApi.Response.Status != null)
                                    &&  (PandaDocUtils.StringToDocumentStatusDomain(documentStatusApi.Response.Status) == DocumentStatusDomain.Draft)
                                )
                                {
                                    ClientUtils.LogError("!");

                                    // Stop Checking when Status == Draft
                                    bReady = true;
                                }
                                else // != Draft
                                {
                                    ClientUtils.LogError("...");

                                    // Keep Checking...
                                    bReady = false;
                                }

                            } // if !bErrors

                        } // response != null

                    } // responseHttp != null

                } // documentStatusApi != null

            } // Valid Input

            // Final Answer
            return bReady;

        } // DocumentStatusReady

        public static bool SendDocument(PandaDocHttpClient client, string strDocumentId)
        {

            bool bSent = false;
            bool bErrors = false;

            // Validate Input
            if ((client != null) && !string.IsNullOrEmpty(strDocumentId))
            {

                // Validate Api
                DocumentSendApi documentSendApi = new DocumentSendApi(client);
                if (documentSendApi != null)
                {

                    //
                    // Setup Request Parameters...
                    //

                    documentSendApi.Request.Subject = "Our NDA document has been drafted";
                    documentSendApi.Request.Message = "Please review and electronically sign the Agreement...";
                    documentSendApi.Request.Silent = false;

                    // Execute Api
                    try
                    {
                        documentSendApi.DocumentSend(strDocumentId);
                    }
                    catch (Exception ex)
                    {
                        ClientUtils.LogExceptions(ex, "DocumentSend.Exception", strDocumentId);
                        bErrors = true;
                    }

                    // Evaluate Response
                    if (documentSendApi.HttpResponse == null)
                    {
                        ClientUtils.LogError("  HttpResonse IS NULL");
                        bErrors = true;
                    }
                    else // if (documentSendApi.HttpResponse is not null)
                    {

                        // Log Response Errors
                        if ((documentSendApi.HttpResponse.Errors != null) && (documentSendApi.HttpResponse.Errors.Count > 0))
                        {
                            ClientUtils.LogErrors(documentSendApi.HttpResponse.Errors, "  ");
                        }

                        // Log Response Status Errors
                        if (!documentSendApi.HttpResponse.IsSuccessStatusCode)
                        {
                            ClientUtils.LogError("Execution HttpResponse Error:" + documentSendApi.HttpResponse.StatusCode.ToString());
                        }

                        // Any Problems?
                        bErrors = bErrors || !documentSendApi.HttpResponse.IsSuccessStatusCode;

                        // Evaluate Response Class
                        if (documentSendApi.Response != null)
                        {

                            // Success?
                            if (bErrors)
                            {

                                // Log Details
                                ClientUtils.LogError("Error:SendDocument:");
                                ClientUtils.LogError("  id:" + documentSendApi.Response.Id);
                                ClientUtils.LogError("  status:" + documentSendApi.Response.Status);
                                ClientUtils.LogError("  type:" + documentSendApi.Response.Type);
                                ClientUtils.LogError("  detail:" + documentSendApi.Response.Detail);
                                ClientUtils.LogError("  info_message:" + documentSendApi.Response.InfoMessage);

                                bSent = false;

                            }
                            else // if (responseHttp.IsSuccessStatusCode)
                            {

                                // Log Details
                                ClientUtils.LogError("Success:SendDocument:");
                                ClientUtils.LogError("  uuid:" + documentSendApi.Response.Uuid);
                                ClientUtils.LogError("  status:" + documentSendApi.Response.Status);

                                bSent = true;

                            } // resonsehttp Successful

                        } // response != null

                    } // responseHttp != null

                } // documentSendApi != null

            } // Valid Input

            // Final Answer
            return bSent;

        } // SendDocument

    } // class ClientHelpers

} // namespace
