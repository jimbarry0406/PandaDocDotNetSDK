using Flurl;
using System;
using System.Linq;

namespace PandaDocDotNetSDK
{
    public abstract class PandaDocUrlQueryParams
    {

        protected string[]? _names = null; // allowable Parameter Names, must be defined in child class

        private readonly QueryParamCollection _queryParams = new QueryParamCollection();

        public QueryParamCollection QueryParams { get { return _queryParams; } }

        public int ParameterCount { get { try { if (QueryParams == null) { return 0; } else { return QueryParams.Count; } } catch { return 0; } } }

        public void RemoveQueryParam(string name)
        {

            // Validate Name
            if (string.IsNullOrEmpty(name))
            {
                return; // bail out gracefully when input name is empty/null
            }

            // Validate Allowable Name use-cases
            if ((_names == null) || (_names.Length == 0) || !_names.Contains(name))
            {
                throw new InvalidOperationException("Parameter [" + name + "] is not a valid name from (" + (((_names == null) || (_names.Length == 0)) ? "<NULL>" : String.Join(";", _names)) + ").");
            }

            // Remove Parameter
            if (QueryParams != null)
            {
                if (QueryParams.Contains(name))
                {
                    _queryParams.Remove(name);
                }
            }

        } // RemoveQueryParam

        public void SetQueryParam(string name, object value, bool bIsEncoded = false, NullValueHandling nullValueHandling = NullValueHandling.Remove)
        {

            // Validate Name
            if (string.IsNullOrEmpty(name))
            {
                return; // bail out gracefully when input name is empty/null
            }

            // Validate Allowable Name use-cases
            if ((_names == null) || (_names.Length == 0) || !_names.Contains(name))
            {
                throw new InvalidOperationException("Parameter [" + name + "] is not a valid name from (" + (((_names == null) || (_names.Length == 0)) ? "<NULL>" : String.Join(";", _names)) + ").");
            }

            // Validate Collection
            if (QueryParams != null)
            {

                // Clear (if it already exists)
                if (QueryParams.Contains(name))
                {
                    _queryParams.Remove(name);
                }

                // Add Parameter
                _queryParams.Add(name, value, bIsEncoded, nullValueHandling);

            } // Valid Collection

        } // SetQueryParam

        public string GetQueryParamString(string name)
        {

            object? value = GetQueryParam(name);
            if (value == null)
            {
                return String.Empty;
            }
            else // if (value != null)
            {
                return value.ToString()!;
            }

        } // GetQueryParamString

        public Int32 GetQueryParamInt32(string name)
        {

            object? value = GetQueryParam(name);
            if (value == null)
            {
                return 0;
            }
            else
            {
                Int32 i = 0;
                try
                {
                    i = (Int32)value;
                }
                catch
                {
                    i = 0;
                }
                return i;
            }

        } // GetQueryParamInt32

        public bool GetQueryParamBool(string name)
        {

            object? value = GetQueryParam(name);
            if (value == null)
            {
                return false;
            }
            else
            {
                bool b = false;
                try
                {
                    b = (bool)value;
                }
                catch
                {
                    b = false;
                }
                return b;
            }

        } // GetQueryParamBool

        public object? GetQueryParam(string name)
        {

            object? value = null;

            // Validate Name
            if (!string.IsNullOrEmpty(name))
            {

                // Validate Allowable Name use-cases
                if ((_names == null) || (_names.Length == 0) || !_names.Contains(name))
                {
                    throw new InvalidOperationException("Parameter [" + name + "] is not a valid name from (" + (((_names == null) || (_names.Length == 0)) ? "<NULL>" : String.Join(";", _names)) + ").");
                }
                else // Valid Allowable Name
                {

                    // Fetch Current Parameter Value
                    if (QueryParams != null)
                    {
                        if (QueryParams.Contains(name))
                        {
                            _queryParams.TryGetFirst(name, out value);
                        }
                    }

                } // Valid Allowable Name

            } // name != null

            return value;

        } // GetQueryParam

        public void CloneQueryParamsToUrl(ref Url url)
        {

            // Clear target query params
            url.QueryParams.Clear();

            // Clone our query parameters over to target
            if ((QueryParams != null) && (ParameterCount > 0))
            {
                foreach (var (Name, Value) in QueryParams)
                {
                    url.SetQueryParam(Name, Value);
                }
            }

        } // CloneQueryParamsToUrl

        protected PandaDocUrlQueryParams() // constructor
        {

        }

    } // abstract class PandaDocUrlQueryParams

} // namespace
