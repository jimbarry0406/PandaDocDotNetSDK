using System;
using System.Collections.Generic;

namespace PandaDocDotNetSDK.API
{

    public abstract class PandaDocApi
    {

        private readonly PandaDocHttpClient _client;
        public PandaDocHttpClient Client { get { return _client; } }

        protected virtual bool ValidApiInput() // Common Method, override as required
        {

            List<string> errors = new List<string>();

            // validate Client
            if (Client == null)
            {
                errors.Add("Client Object IS NULL/Empty");
            }

            if (errors.Count > 0)
            {
                throw new ArgumentOutOfRangeException(string.Join("\r\n", errors));
            }

            return true;

        } // ValidApiInput

        protected PandaDocApi(PandaDocHttpClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            _client = client;
        }

    } // PandaDocApi

} // namespace