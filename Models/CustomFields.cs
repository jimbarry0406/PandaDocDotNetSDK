using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class CustomFields
    {

        //
        // Constructors
        //

        public CustomFields() : base()
        { 
        }

/*
        [JsonConstructor]
        public CustomFields(
            [JsonProperty("id")] object id = null,
        ) : base()
        {
        }
*/

        public CustomFields(CustomFields customFields) : base()
        {
        }

        //
        // Read-Write Attributes
        //

        //
        // Read-Only Attributes
        //

        //
        // Methods
        //

    } // class CustomFields

} // namespace
