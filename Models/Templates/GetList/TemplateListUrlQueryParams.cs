using System;

namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/list-templates

    // reference
    //  https://openapi.pandadoc.com/#/operations/listTemplates

    public class TemplateListUrlQueryParams : PandaDocUrlQueryParams
    {

        // "count", // integer<int32>, Specify how many templates to return. Default is 50 templates, maximum is 100 templates.
        public Int32 Count { get { return GetQueryParamInt32("count"); } set { SetQueryParam("count", value); } }

        // "deleted", // boolean,  Return only the deleted templates.
        public bool Deleted { get { return GetQueryParamBool("deleted"); } set { SetQueryParam("deleted", value); } }

        // "folder_uuid", // string, UUID of the folder where the templates are stored.
        public string FolderUuid { get { return GetQueryParamString("folder_uuid"); } set { SetQueryParam("folder_uuid", value); } }

        // "id", // string,specify template ID.
        public string Id { get { return GetQueryParamString("id"); } set { SetQueryParam("id", value); } }

        // "page", // integer<int32>, specify which page of the dataset to return. >= 1
        public Int32 Page { get { return GetQueryParamInt32("page"); } set { SetQueryParam("page", value); } }

        // "q", // string (query Name), search query. Filter by template name.
        public string Name { get { return GetQueryParamString("q"); } set { SetQueryParam("q", value); } }

        // "shared", // boolean, Returns only the shared templates.
        public bool Shared { get { return GetQueryParamBool("shared"); } set { SetQueryParam("shared", value); } }

        // "tag", // string, search tag. Filter by template tag.
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
