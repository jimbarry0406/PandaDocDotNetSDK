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

        public static bool GetTemplateList(PandaDocHttpClient client)
        {

            bool bErrors = false;

            // Validate Client
            if (client != null)
            {

                // Validate Api
                TemplateListApi templateListApi = new TemplateListApi(client);
                if (templateListApi != null)
                {

                    //
                    // Setup Query Parameters...
                    //

                    // Look for Templates tagged with "outlook"
                    templateListApi.UrlQueryParms.Tag = "outlook";

                    //
                    // Alternative Method, using Collection and KvP
                    // templateListApi.UrlQueryParms.SetQueryParam("tag", "outlook")
                    //

                    // Execute Api
                    try
                    {
                        templateListApi.GetTemplateList();
                    }
                    catch (Exception ex)
                    {
                        ClientUtils.LogExceptions(ex, "GetTemplateList.Exception");
                        bErrors = true;
                    }

                    // Evaluate Response
                    if (templateListApi.HttpResponse == null)
                    {
                        ClientUtils.LogError("  HttpResonse IS NULL");
                        bErrors = true;
                    }
                    else // if (templateListApi.HttpResponse is not null)
                    {

                        // Log Response Errors
                        if ((templateListApi.HttpResponse.Errors != null) && (templateListApi.HttpResponse.Errors.Count > 0))
                        {
                            ClientUtils.LogErrors(templateListApi.HttpResponse.Errors, "  ");
                        }

                        // Log Response Status Errors
                        if (!templateListApi.HttpResponse.IsSuccessStatusCode)
                        {
                            ClientUtils.LogError("Execution HttpResponse Error:" + templateListApi.HttpResponse.StatusCode.ToString());
                        }

                        // Any Problems?
                        bErrors = bErrors || !templateListApi.HttpResponse.IsSuccessStatusCode;

                        // Evaluate Response Class
                        if (templateListApi.Response != null)
                        {

                            // Success?
                            if (bErrors)
                            {

                                // Log List
                                ClientUtils.LogError("Error:TemplateList:");
                                ClientUtils.LogError("  type:" + templateListApi.Response.Type);
                                ClientUtils.LogError("  detail:" + templateListApi.Response.Detail);
                                ClientUtils.LogError("  Errors.Count:" + templateListApi.HttpResponse.Errors?.Count.ToString());
                                ClientUtils.LogError("  IsSuccessStatusCode:" + templateListApi.HttpResponse.IsSuccessStatusCode.ToString());

                            }
                            else if ((templateListApi.Response != null) && (templateListApi.Response.Templates != null))
                            {

                                // Log List
                                ClientUtils.LogError("  TemplateList...");
                                ClientUtils.LogError("  ==================");
                                ClientUtils.LogError("    Templates.Length:" + templateListApi.Response.Templates.Length.ToString());
                                foreach (Template template in templateListApi.Response.Templates!)
                                {
                                    ClientUtils.LogError("  Template.Id:" + template.Id);
                                    ClientUtils.LogError("  Template.Name:" + template.Name);
                                }

                            } // resonsehttp Successful

                        } // response != null

                    } // responseHttp != null

                } // templateListApi != null

            } // client != null

            // Process Request
            return !bErrors;

        } // GetTemplateList

        public static bool GetTemplateDetails(PandaDocHttpClient client, string strTemplateId)
        {

            bool bErrors = false;

            // Validate Input
            if ((client != null) && !string.IsNullOrEmpty(strTemplateId))
            {

                // Validate Api
                TemplateDetailsApi templateDetailsApi = new TemplateDetailsApi(client);
                if (templateDetailsApi != null)
                {

                    //
                    // No Request or Query Parameters...
                    //

                    // Execute Api
                    try
                    {
                        templateDetailsApi.GetTemplateDetails(strTemplateId);
                    }
                    catch (Exception ex)
                    {
                        ClientUtils.LogExceptions(ex, "GetTemplateDetails.Exception", strTemplateId);
                        bErrors = true;
                    }

                    // Evaluate Response
                    if (templateDetailsApi.HttpResponse == null)
                    {
                        ClientUtils.LogError("  HttpResonse IS NULL");
                        bErrors = true;
                    }
                    else // if (templateDetailsApi.HttpResponse is not null)
                    {

                        // Log Response Errors
                        if ((templateDetailsApi.HttpResponse.Errors != null) && (templateDetailsApi.HttpResponse.Errors.Count > 0))
                        {
                            ClientUtils.LogErrors(templateDetailsApi.HttpResponse.Errors, "  ");
                        }

                        // Log Response Status Errors
                        if (!templateDetailsApi.HttpResponse.IsSuccessStatusCode)
                        {
                            ClientUtils.LogError("Execution HttpResponse Error:" + templateDetailsApi.HttpResponse.StatusCode.ToString());
                        }

                        // Any Problems?
                        bErrors = bErrors || !templateDetailsApi.HttpResponse.IsSuccessStatusCode;

                        // Evaluate Response Class
                        if (templateDetailsApi.Response != null)
                        {

                            // Success?
                            if (bErrors)
                            {

                                // Log Details
                                ClientUtils.LogError("Error:TemplateDetails:");
                                ClientUtils.LogError("  type:" + templateDetailsApi.Response.Type);
                                ClientUtils.LogError("  detail:" + templateDetailsApi.Response.Detail);
                                ClientUtils.LogError("  Errors.Count:" + templateDetailsApi.HttpResponse.Errors?.Count.ToString());
                                ClientUtils.LogError("  IsSuccessStatusCode:" + templateDetailsApi.HttpResponse.IsSuccessStatusCode.ToString());

                            }
                            else // if (responseHttp.IsSuccessStatusCode)
                            {


                                // Log Details
                                ClientUtils.LogError("  TemplateDetails...");
                                ClientUtils.LogError("  ==================");
                                ClientUtils.LogError("    Name:" + templateDetailsApi.Response.Name);
                                ClientUtils.LogError("    Id:" + templateDetailsApi.Response.Id);
                                DateTime? created = templateDetailsApi.Response.DateCreated;
                                if (created != null)
                                {
                                    ClientUtils.LogError("    DateCreated:" + ((DateTime)created).ToString("G"));
                                }
                                ClientUtils.LogError("    Version:" + templateDetailsApi.Response.Version);

                                foreach (Token t in templateDetailsApi.Response.DefaultVariables!)
                                {
                                    ClientUtils.LogError("    test of general DefaultVariables Array:" + t.Name + "." + t.Value);
                                }

                                ClientUtils.LogError("    test of specific GetDefaultVariable Method Defaults.Document.Name:" + templateDetailsApi.Response.GetDefaultVariableString("Defaults.Document.Name"));

                            } // resonsehttp Successful

                        } // response != null

                    } // responseHttp != null

                } // templateDetailsApi != null

            } // Valid Input

            // Process Request
            return !bErrors;

        } // GetTemplateDetails

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

        public static string CreateDocumentFromNdaTemplate(PandaDocHttpClient client)
        {

            string strDocumentId = String.Empty;
            bool bErrors = false;

            // Validate Client
            if (client != null)
            {

                // Validate Api
                DocumentCreateApi documentCreateApi = new DocumentCreateApi(client, DocumentCreateMethod.FromTemplate);
                if (documentCreateApi != null)
                {

                    // Generate a Cilent-Side Guid
                    string strDocumentGuid = Guid.NewGuid().ToString().Replace("-", "");

                    //
                    // Setup Request Parameters...
                    //

                    documentCreateApi.Request.TemplateUuid = ClientUtils.ClientSetup!.PandaDocNdaTemplateId;

                    // Define Name (may be overidden in Template)
                    documentCreateApi.Request.Name = "NDA";

                    //documentCreateApi.Request.Owner.Set("me@domain.com")

                    documentCreateApi.Request.Recipients.Add(
                        new DocumentRecipient(
                            email: ClientUtils.ClientSetup!.PandaDocTestClientEmail,
                            role: "Client",
                            signingOrder: "1"
                        ));

                    documentCreateApi.Request.Recipients.Add(
                        new DocumentRecipient(
                            email: ClientUtils.ClientSetup!.PandaDocTestSenderEmail,
                            role: "Sender",
                            signingOrder: "2"
                        ));

                    // fields (assigned or unassigned)
                    //documentCreateApi.Request.Fields.Add("MergeField.Today", new Field(DateTime.Now.ToString("MM/dd/yyyy"))); // Use [second] Merge Field (Name), *not* [first] Field Id

                    // metadata
                    //documentCreateApi.Request.Metadata.Add("my_favorite_pet", "Panda")

                    // tags
                    documentCreateApi.Request.Tags.Set(new string[] { "created_via_api", "demo", "nda" });

                    // tokens = variables
                    documentCreateApi.Request.Tokens.Add(new Token("Document.Guid", strDocumentGuid));

                    // Alter Document Name
                    documentCreateApi.Request.Name += (" - " + strDocumentGuid);

                    // Execute Api
                    try
                    {
                        documentCreateApi.DocumentCreate();
                    }
                    catch (Exception ex)
                    {
                        ClientUtils.LogExceptions(ex, "DocumentCreate.Exception");
                        bErrors = true;
                    }

                    // Evaluate Response
                    if (documentCreateApi.HttpResponse == null)
                    {
                        ClientUtils.LogError("  HttpResonse IS NULL");
                        bErrors = true;
                    }
                    else // if (documentCreateApi.HttpResponse is not null)
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
                            else if (documentCreateApi.Response != null)
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

        } // CreateDocumentFromNdaTemplate

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
