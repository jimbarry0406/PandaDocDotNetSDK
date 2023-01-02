using Flurl;
using System;

namespace PandaDocDotNetSDK
{
    public class PandaDocHttpClientSettings
    {

        private const string _strDefaultApiBase = @"https://api.pandadoc.com";
        private const string _strDefaultApiInstance = @"public/v1";

        private const string _strApiDocuments = @"documents";
        private const string _strApiTemplates = @"templates";

        private string? _strApiKey;
        private string? _strApiBase;
        private string? _strApiInstance;

        public PandaDocHttpClientSettings(
            string? strApiKey, 
            string? strApiBase = null, 
            string? strApiInstance = null
        )
        {
            StrApiKey = strApiKey;
            StrApiBase = strApiBase;
            StrApiInstance = strApiInstance;
        }

        public string? StrApiKey
        {
            get { return _strApiKey; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _strApiKey = value;
                }
                else
                {
                    _strApiKey = String.Empty;
                }
            }
        }

        public string? StrApiBase
        {
            get { return _strApiBase; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _strApiBase = value;
                }
                else
                {
                    _strApiBase = _strDefaultApiBase;
                }
            }
        }

        public string? StrApiInstance
        {
            get { return _strApiInstance; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _strApiInstance = value;
                }
                else
                {
                    _strApiInstance = _strDefaultApiInstance;
                }
            }
        }

        public string StrApiDocuments
        {
            get { return Url.Combine(StrApiBase, StrApiInstance, _strApiDocuments); }
        }

        public string StrApiTemplates
        {
            get { return Url.Combine(StrApiBase, StrApiInstance, _strApiTemplates); }
        }

    } // class PandaDocHttpClientSettings

} // namespace PandaDocDotNetSDK
