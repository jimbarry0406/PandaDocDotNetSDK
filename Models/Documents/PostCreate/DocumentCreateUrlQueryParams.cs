namespace PandaDocDotNetSDK.Models
{

    // documentation
    //  https://developers.pandadoc.com/reference/create-document-from-pdf

    // reference
    //  https://openapi.pandadoc.com/#/schemas/DocumentCreateByPdfRequest

    public class DocumentCreateUrlQueryParams : PandaDocUrlQueryParams
    {

        // "editor_ver", // string
        public string EditorVer { get { return GetQueryParamString("editor_ver"); } set { SetQueryParam("editor_ver", value); } }
        /*
         * Set this parameter as ev1 if you want to create a document from PDF with Classic Editor when both editors are enabled for the workspace.
         * 
         * Only use for Create from File (not Templates)
         * 
         */

        public DocumentCreateUrlQueryParams() : base()
        {

            // Define allowable Parameter Names
            _names = new string[]
            {
                "editor_ver" // string
            };

        }

    } // class DocumentCreateUrlQueryParams

} // namespace
