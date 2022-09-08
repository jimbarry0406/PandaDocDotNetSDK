using System;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/list-templates

    // reference
    //  https://openapi.pandadoc.com/#/operations/listTemplates

    public class TemplateListUrlQueryParams : PandaDocUrlQueryParams
    {

        // "count", // integer<int32>
        public Int32 Count { get { return GetQueryParamInt32("count"); } set { SetQueryParam("count", value); } }

        // "deleted", // boolean
        public bool Deleted { get { return GetQueryParamBool("deleted"); } set { SetQueryParam("deleted", value); } }

        // "folder_uuid", // string
        public string FolderUuid { get { return GetQueryParamString("folder_uuid"); } set { SetQueryParam("folder_uuid", value); } }

        // "id", // string
        public string Id { get { return GetQueryParamString("id"); } set { SetQueryParam("id", value); } }

        // "page", // integer<int32>
        public Int32 Page { get { return GetQueryParamInt32("page"); } set { SetQueryParam("page", value); } }

        // "q", // string (query Name)
        public string Name { get { return GetQueryParamString("q"); } set { SetQueryParam("q", value); } }

        // "shared", // boolean
        public bool Shared { get { return GetQueryParamBool("shared"); } set { SetQueryParam("shared", value); } }

        // "tag", // string
        public string Tag { get { return GetQueryParamString("tag"); } set { SetQueryParam("tag", value); } }

        public TemplateListUrlQueryParams() : base()
        {

            // Define allowable Parameter Names
            _names = new string[]
            {
                "count", // integer<int32>
                "deleted", // boolean
                "folder_uuid", // string
                "id", // string
                "page", // integer<int32>
                "q", // string (query Name)
                "shared", // boolean
                "tag", // string
            };

        } // TemplateListUrlQueryParams

    } // class

} // namespace
