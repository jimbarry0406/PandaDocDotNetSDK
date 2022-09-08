using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

//
// Public Utils, for use within the local library code *AND* any consuming client code
//

namespace PandaDocDotNetSDK
{

    public enum DocumentCreateMethod
    {
        FromTemplate = 0, // default
        FromLocalFile = 1,
        FromUrlFile = 2
    }

    public enum DocumentStatusDomain
    {
        Draft = 0,
        Sent = 1,
        Compelted = 2,
        Uploaded = 3,
        Error = 4,
        Viewed = 5,
        WaitingApproval = 6,
        Approved = 7,
        Rejected = 8,
        WaitingPay = 9,
        Paid = 10,
        Voided = 11,
        Declined = 12,
        ExternalReview = 13,
        Unknown = 99 // default
    }

    public static class ApiUtils
    {

        public static string ConvertDocumentCreateMethodToString(DocumentCreateMethod? method)
        {

            string? value = null;

            // Attempt Conversion
            try
            {
                Type? type = typeof(DocumentCreateMethod);
                if ((type != null) && (method != null))
                {
                    value = Enum.GetName(type, method);
                }
            }
            catch
            {
                value = null;
            }

            if (value == null)
            {
                value = String.Empty;
            }

            return value;

        } // ConvertDocumentCreateMethodToString

        public static DocumentCreateMethod ConvertStringToDocumentCreateMethod(string method)
        {

            DocumentCreateMethod value = DocumentCreateMethod.FromTemplate;

            // Attempt Conversion
            try
            {
                value = (DocumentCreateMethod)Enum.Parse(typeof(DocumentCreateMethod), method);
            }
            catch
            {
                value = DocumentCreateMethod.FromTemplate;
            }

            return value;

        } // ConvertStringToDocumentCreateMethod

        public static string ConvertDocumentStatusDomainToString(DocumentStatusDomain? status)
        {

            string? value = null;

            // Attempt Conversion
            try
            {
                System.Type? type = typeof(DocumentStatusDomain);
                if ((type != null) && (status != null))
                {
                    value = Enum.GetName(type, status);
                }
            }
            catch
            {
                value = null;
            }

            if (value == null)
            {
                value = String.Empty;
            }

            return value;

        } // ConvertDocumentStatusDomainToString

        public static DocumentStatusDomain ConvertStringToDocumentStatusDomain(string status)
        {

            DocumentStatusDomain value = DocumentStatusDomain.Unknown;

            // Attempt Conversion
            try
            {
                value = (DocumentStatusDomain)Enum.Parse(typeof(DocumentStatusDomain), status);
            }
            catch
            {
                value = DocumentStatusDomain.Unknown;
            }

            return value;

        } // ConvertStringToDocumentStatusDomain

    } // class ApiUtils

} // namespace PandaDocDotNetSDK
