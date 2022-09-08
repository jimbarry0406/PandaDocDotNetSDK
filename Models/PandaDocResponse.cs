using Newtonsoft.Json;
using System;

namespace PandaDocDotNetSDK.Models
{

    public class PandaDocResponse
    {

        //
        // Constructors
        //

        public PandaDocResponse()
        {
        }

        //
        // Read-Write Attributes
        //

        // tokens array[object]
        [JsonProperty("tokens")]
        public Token[]? Tokens { get; set; }


        //
        // Read-Only Attributes (mostly for Error Handling)
        //

        [JsonProperty("type")]
        public string? Type { get; }

        [JsonProperty("detail")]
        public string? Detail { get; }

        // info_message string
        [JsonProperty("info_message")]
        public string? InfoMessage { get; }


        //
        // Default Variable Methods
        //

        [JsonIgnore]
        public Token[]? DefaultVariables
        {
            get
            {
                if (Tokens == null)
                {
                    return null;
                }
                else
                {
                    return Array.FindAll<Token>(Tokens, t => ((t != null) && (t.Name != null) && t.Name.StartsWith("Defaults.")));
                }
            }
        }

        [JsonIgnore]
        private bool _defaultsCached = false;

        [JsonIgnore]
        private Token[]? _defaultsCache = null;

        public string? GetDefaultVariableString(
            string name, 
            string? defaultValue = null
        )
        {

            object? oDefaultValue = null;
            if (!string.IsNullOrWhiteSpace(defaultValue))
            {
                oDefaultValue = defaultValue as object;
            }

            object? value = GetDefaultVariable(name, oDefaultValue);
            if (value == null)
            {
                return (defaultValue ?? String.Empty);
            }
            else
            {
                return value.ToString();
            }

        } // GetDefaultVariableString

        public object? GetDefaultVariable(string name, object? defaultValue = null)
        {

            object? value = null;

            // Assign/Cache Default Variables
            if (!_defaultsCached)
            {
                try
                {
                    Token[]? defaults = DefaultVariables;
                    if (defaults == null)
                    {
                        _defaultsCache = null;
                    }
                    else
                    {
                        _defaultsCache = InternalApiUtils.ArrayCreateDeepCopy<Token>(defaults);
                    }
                }
                catch
                {
                    _defaultsCache = null;
                    throw;
                }
                finally
                {
                    _defaultsCached = true;
                }
            }

            // Validate Cache of Default Variables
            if ((_defaultsCache != null) && (_defaultsCache.Length > 0))
            {

                // Validate Input
                if (!string.IsNullOrEmpty(name))
                {

                    // Attempt to Find Value
                    value = InternalApiUtils.FindArrayElementValue<Token>(_defaultsCache, t => t.Name == name, defaultValue);

                } // Valid Input

            } // Valid Cache

            return value;

        } // GetDefaultVariable

    } // class PandaDocResponse

} // namespace
