using System;
using System.Collections.Generic;

namespace PandaDocDotNetSDK.Models
{

    public class OwnerProxy
    {

        //
        // Private Members
        //
        private string _owner = String.Empty;

        //
        // Constructors

        public OwnerProxy() : base()
        {
            Clear();
        }

        public OwnerProxy(string owner) : base()
        {
            Set(owner);
        }

        public OwnerProxy(OwnerProxy ownerProxy) : base()
        {
            Set(ownerProxy.Get());
        }

        //
        // Methods
        //

        public void Clear()
        {
            Set(String.Empty);
        }

        public void Set(string owner)
        {
            _owner = owner;
        }

        public string Get()
        {
            return _owner;
        }

        public bool ShouldSerialize()
        {
            return (!string.IsNullOrEmpty(Get()));
        }

        // Return Owner as a Dictionary entry, to support Json formatting use-cases
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1168:Empty arrays and collections should be returned instead of null", Justification = "Empty Dictionary will Serialize, Null will *not* Serialize")]
        public Dictionary<string, string>? ToJsonObject()
        {

            if (ShouldSerialize())
            {
                string owner = Get();
                Dictionary<string, string> entry = new Dictionary<string, string>(1);
                if (entry != null)
                {
                    string name = (owner.Contains("@") ? "email" : "membership_id");
                    entry.Add(name, owner);
                }
                return entry;
            }
            else
            {
                return null;
            }

        } // ToJsonObject

    } // class OwnerProxy

} // namespace PandaDocDotNetSDK.Models
