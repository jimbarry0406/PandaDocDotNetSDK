using PandaDocDotNetSDK.Models;
using System;

namespace PandaDocDotNetSDK
{

    public static class PandaDocUtils
    {
        public static DocumentStatusDomain StringToDocumentStatusDomain(string status)
        {

            DocumentStatusDomain value = DocumentStatusDomain.Unknown;

            switch (status)
            {
                case "document.uploaded":
                    value = DocumentStatusDomain.Uploaded;
                    break;
                case "document.draft":
                    value = DocumentStatusDomain.Draft;
                    break;
                case "document.sent":
                    value = DocumentStatusDomain.Sent;
                    break;
                case "document.viewed":
                    value = DocumentStatusDomain.Viewed;
                    break;
                case "document.waiting_approval":
                    value = DocumentStatusDomain.WaitingApproval;
                    break;
                case "document.rejected":
                    value = DocumentStatusDomain.Rejected;
                    break;
                case "document.approved":
                    value = DocumentStatusDomain.Approved;
                    break;
                case "document.waiting_pay":
                    value = DocumentStatusDomain.WaitingPay;
                    break;
                case "document.paid":
                    value = DocumentStatusDomain.Paid;
                    break;
                case "document.completed":
                    value = DocumentStatusDomain.Compelted;
                    break;
                case "document.voided":
                    value = DocumentStatusDomain.Voided;
                    break;
                case "document.declined":
                    value = DocumentStatusDomain.Declined;
                    break;
                case "document.external_review":
                    value = DocumentStatusDomain.ExternalReview;
                    break;
                case "document.error":
                    value = DocumentStatusDomain.Error;
                    break;
                default:
                    value = DocumentStatusDomain.Unknown;
                    break;
            }

            return value;

        } // StringToDocumentStatus

        public static string DocumentStatusDomainToString(DocumentStatusDomain status)
        {

            string value = String.Empty;

            switch (status)
            {
                case DocumentStatusDomain.Uploaded:
                    value = "document.uploaded";
                    break;
                case DocumentStatusDomain.Draft:
                    value = "document.draft";
                    break;
                case DocumentStatusDomain.Sent:
                    value = "document.sent";
                    break;
                case DocumentStatusDomain.Viewed:
                    value = "document.viewed";
                    break;
                case DocumentStatusDomain.WaitingApproval:
                    value = "document.waiting_approval";
                    break;
                case DocumentStatusDomain.Rejected:
                    value = "document.rejected";
                    break;
                case DocumentStatusDomain.Approved:
                    value = "document.approved";
                    break;
                case DocumentStatusDomain.WaitingPay:
                    value = "document.waiting_pay";
                    break;
                case DocumentStatusDomain.Paid:
                    value = "document.paid";
                    break;
                case DocumentStatusDomain.Compelted:
                    value = "document.completed";
                    break;
                case DocumentStatusDomain.Voided:
                    value = "document.voided";
                    break;
                case DocumentStatusDomain.Declined:
                    value = "document.declined";
                    break;
                case DocumentStatusDomain.ExternalReview:
                    value = "document.external_review";
                    break;
                case DocumentStatusDomain.Error:
                    value = "document.error";
                    break;
                default:
                    value = String.Empty;
                    break;
            }

            return value;

        } // DocumentStatusToString

    } // class PandaDocUtils

} // namespace PandaDocDotNetSDK
