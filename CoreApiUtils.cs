using Microsoft.AspNetCore.StaticFiles;

//
// .NET Core Utils, only for used when compiling for .NET Core
//

namespace PandaDocDotNetCoreSDK
{
    internal static class CoreApiUtils
    {

        public static string GetMimeType(string fileName)
        {
            string contentType = String.Empty;

            if (!String.IsNullOrEmpty(fileName))
            {
                FileExtensionContentTypeProvider? provider = new FileExtensionContentTypeProvider();
                if (provider != null)
                {
                    if (!provider.TryGetContentType(fileName, out contentType))
                    {
                        contentType = "application/octet-stream";
                    }
                }
            }

            return contentType;

        } // GetMimeType

    } // class CoreApiUtils

} // namespace
