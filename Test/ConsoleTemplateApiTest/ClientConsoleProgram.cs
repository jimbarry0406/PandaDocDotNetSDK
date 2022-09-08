﻿using ConsoleTemplateApiTest;
using Newtonsoft.Json;
using PandaDocDotNetSDK;

// See https://aka.ms/new-console-template for more information

// Load Settings
ClientUtils.LoadClientSetup();

// Verify Settings
if (ClientUtils.ClientSetup == null)
{
    Console.WriteLine("ERROR: Could Not Load Settings!");
}
else // if (ClientUtils.ClientSetup is not null)
{
    // Show Settings
    Console.WriteLine("client_setup.json:" + JsonConvert.SerializeObject(ClientUtils.ClientSetup));

    // client
    PandaDocHttpClient client = new PandaDocHttpClient(ClientUtils.ClientSetup.PandaDocApiKey!);
    if (client != null)
    {

        // Get Template List (Test getting a Template list)
        if (ClientHelpers.GetTemplateList(client))
        {
            ClientUtils.LogError("Template List Was Found");
        }
        else
        {
            ClientUtils.LogError("Template Was Not Found");
        }

        // Get Template Details (Test downloading the Template Details)
        if (ClientHelpers.GetTemplateDetails(client, ClientUtils.ClientSetup.PandaDocNdaTemplateId!))
        {
            ClientUtils.LogError("Template Was Downloaded");
        }
        else
        {
            ClientUtils.LogError("Template Was Not Downloaded Successfully");
        }

        // Create Document from Template
        string strDocumentId = ClientHelpers.CreateDocumentFromNdaTemplate(client);

        // Validate Document
        if (string.IsNullOrEmpty(strDocumentId))
        {
            ClientUtils.LogError("Document Was Not Created from Template");
        }
        else
        {

            // Wait for Document Status == Draft
            bool bImReady = false;
            int nMaxDurationInSeconds = 15;
            for (int checkCount = 0; checkCount < nMaxDurationInSeconds; checkCount++)
            {

                // Get Current Status
                bImReady = ClientHelpers.DocumentStatusReady(client, strDocumentId);

                // Check Current Status
                if (bImReady)
                {
                    // break when we are Ready
                    break;
                }
                else // keep going, after short delay, up to max tries
                {
                    Thread.Sleep(1000); // blocks current thread for one second, assumes we are on a single-thread, or the background thread pool, long delay here to mitigate against API throttle limits
                }

            } // iterate through max attempts

            // Not-Ready EdgeCases
            if (!bImReady)
            {
                ClientUtils.LogError("Document was not created in a Timely manner");
            }
            else // Document is now Ready...
            {

                // Get Document Details (Test downloading the Document Details)
                if (ClientHelpers.GetDocumentDetails(client, strDocumentId))
                {
                    ClientUtils.LogError("Document Was Downloaded");
                }
                else
                {
                    ClientUtils.LogError("Document Was Not Downloaded Successfully");
                }

                // Send Document to all Parties
                if (ClientHelpers.SendDocument(client, strDocumentId))
                {
                    ClientUtils.LogError("Document Sent");
                }
                else
                {
                    ClientUtils.LogError("Document Was Not Sent Successfully");
                }

            } // Document is now Ready

        } // valid Document

    } // client != null

} // LoadClientSetup
