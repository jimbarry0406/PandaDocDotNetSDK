using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/list-documents

    // reference
    //  https://openapi.pandadoc.com/#/operations/listDocuments

    public class DocumentListUrlQueryParams : PandaDocUrlQueryParams
    {

        // "completed_from", // string<DateTime>, Return results where the date_completed field (ISO 8601) is greater than or equal to this value.
        public DateTime? CompletedFrom { get { return GetQueryParamDateTime("completed_from"); } set { SetQueryParam("completed_from", value); } }

        // "completed_to", // string<DateTime>, Return results where the date_completed field (ISO 8601) is less than or equal to this value.
        public DateTime? CompletedTo { get { return GetQueryParamDateTime("completed_to"); } set { SetQueryParam("completed_to", value); } }

        // "contact_id", // string, Returns results where 'contact_id' is present in document as recipient or approver
        public string ContactId { get { return GetQueryParamString("contact_id"); } set { SetQueryParam("contact_id", value); } }

        // "count", // integer<int32>, Specify how many document results to return. Default is 50 documents, maximum is 100 documents.
        public Int32 Count { get { return GetQueryParamInt32("count"); } set { SetQueryParam("count", value); } }

        // "created_from", // string<DateTime>, Return results where the date_completed field (ISO 8601) is greater than or equal to this value.
        public DateTime? CreatedFrom { get { return GetQueryParamDateTime("created_from"); } set { SetQueryParam("created_from", value); } }

        // "created_to", // string<DateTime>, Return results where the date_completed field (ISO 8601) is less than or equal to this value.
        public DateTime? CreatedTo { get { return GetQueryParamDateTime("created_to"); } set { SetQueryParam("created_to", value); } }

        // "deleted", // boolean, Returns only the deleted documents.
        public bool Deleted { get { return GetQueryParamBool("deleted"); } set { SetQueryParam("deleted", value); } }

        // "folder_uuid", // string, The UUID of the folder where the documents are stored.
        public string FolderUuid { get { return GetQueryParamString("folder_uuid"); } set { SetQueryParam("folder_uuid", value); } }

        // "form_id", // string, Specify the form used for documents creation. *** This parameter can't be used with template_id ***
        public string FormId { get { return GetQueryParamString("form_id"); } set { SetQueryParam("form_id", value); } }

        // "id", // string, Specify document's ID.
        public string Id { get { return GetQueryParamString("id"); } set { SetQueryParam("id", value); } }

        // "membership_id", // string, Returns results where 'membership_id' is present in document as owner (should be member uuid)
        public string MembershipId { get { return GetQueryParamString("membership_id"); } set { SetQueryParam("membership_id", value); } }

/*
        
        // "metadata" array[string], Specify metadata to filter by in the format of metadata_{metadata-key}={metadata-value} such as metadata_opportunity_id=2181432. The metadata_ prefix is always required.
        public Dictionary<string, string> MetadataProxy { get; set; } = new Dictionary<string, string>();
            examples:
                ["metadata_opportunity_id=2181432","metadata_custom_key=custom_value"]

 */

        // "modified_from", // string<DateTime>, Return results where the date_modified field (iso-8601) is greater than or equal to this value.
        public DateTime? ModifiedFrom { get { return GetQueryParamDateTime("modified_from"); } set { SetQueryParam("modified_from", value); } }

        // "modified_to", // string<DateTime>, Return results where the date_modified field (iso-8601) is less than this value.
        public DateTime? ModifiedTo { get { return GetQueryParamDateTime("modified_to"); } set { SetQueryParam("modified_to", value); } }

        // "order_by", // string, Specify the order of documents to return. Use value(for example, date_created) for ASC and -value(for example, -date_created) for DESC.
        public string OrderBy { get { return GetQueryParamString("order_by"); } set { SetQueryParam("order_by", value); } }
/*
            Allowed values:
                name
                date_created
                date_status_changed
                date_of_last_action
                date_modified
                date_sent
                date_completed
                date_expiration
                date_declined
                status
                -name
                -date_created
                -date_status_changed
                -date_of_last_action
                -date_modified
                -date_sent
                -date_completed
                -date_expiration
                -date_declined
                -status
 */

        // "page", // integer<int32>, Specify which page of the dataset to return. >= 1
        public Int32 Page { get { return GetQueryParamInt32("page"); } set { SetQueryParam("page", value); } }

        // "q", // string (query Name), Search query. Filter by document reference number (this token is stored on the template level) or name.
        public string Name { get { return GetQueryParamString("q"); } set { SetQueryParam("q", value); } }

        // "status", // integer, Specify teh status of documents to return
        public DocumentStatusDomain Status { get { return GetQueryParamDocumentStatusDomain("status"); } set { SetQueryParam("status", value); } }

        // "status_ne", // integer, Specify the status of documents to return (***exclude***).
        public DocumentStatusDomain StatusNe { get { return GetQueryParamDocumentStatusDomain("status_ne"); } set { SetQueryParam("status_ne", value); } }

        // "tag", // string, Search tag. Filter by document tag
        public string Tag { get { return GetQueryParamString("tag"); } set { SetQueryParam("tag", value); } }

        // "template_id", // string, Specify the template used for documents creation. *** This parameter can't be used with form_id ***
        public string TemplateId { get { return GetQueryParamString("template_id"); } set { SetQueryParam("template_id", value); } }

        public DocumentListUrlQueryParams() : base()
        {

            // Define allowable Parameter Names
            _names = new string[]
            {
                "completed_from", // string<DateTime>, Return results where the date_completed field (ISO 8601) is greater than or equal to this value.
                "completed_to", // string<DateTime>, Return results where the date_completed field (ISO 8601) is less than or equal to this value.
                "contact_id", // string, Returns results where 'contact_id' is present in document as recipient or approver
                "count", // integer<int32>
                "created_from", // string<DateTime>, Return results where the date_completed field (ISO 8601) is greater than or equal to this value.
                "created_to", // string<DateTime>, Return results where the date_completed field (ISO 8601) is less than or equal to this value.
                "deleted", // boolean, Returns only the deleted documents.
                "folder_uuid", // string, The UUID of the folder where the documents are stored.
                "form_id", // string, Specify the form used for documents creation. *** This parameter can't be used with template_id ***
                "id", // string, Specify document's ID.
                "membership_id", // string, Returns results where 'membership_id' is present in document as owner (should be member uuid)
                "metadata", // array[string], Specify metadata to filter by in the format of metadata_{metadata-key}={metadata-value} such as metadata_opportunity_id=2181432. The metadata_ prefix is always required.
                "modified_from", // string<DateTime>, Return results where the date_modified field (iso-8601) is greater than or equal to this value.
                "modified_to", // string<DateTime>, Return results where the date_modified field (iso-8601) is less than this value.
                "order_by", // string, Specify the order of documents to return. Use value(for example, date_created) for ASC and -value(for example, -date_created) for DESC.
                "page", // integer<int32>, Specify which page of the dataset to return. >= 1
                "q", // string (query Name), Search query. Filter by document reference number (this token is stored on the template level) or name.
                "status", // integer, Specify teh status of documents to return
                "status_ne", // integer, Specify the status of documents to return (***exclude***).
                "tag", // string, Search tag. Filter by document tag
                "template_id"  // string, Specify the template used for documents creation. *** This parameter can't be used with form_id ***
            };

        } // DocumentListUrlQueryParams

    } // class

} // namespace
