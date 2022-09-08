using System;
using System.Web;

//
// .NET Framework Utils, only for used when compiling for .NET Framework
//

namespace PandaDocDotNetFrameworkSDK
{
    internal static class FrameworkApiUtils
    {

        public static string GetMimeType(string fileName)
        {

            string contentType = String.Empty;

            if (!String.IsNullOrEmpty(fileName))
            {
                MimeMapping.GetMimeMapping(fileName);
            }

            return contentType;

        } // GetMimeType

    } // class CoreApiUtils

} // namespace
