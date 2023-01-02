using Flurl;
using PandaDocDotNetSDK.Models;
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

        public void NullifyQueryParam(string? name = null)
        {

            // Nullify == Remove
            RemoveQueryParam(name);

        } // NullifyQueryParam

        public void RemoveQueryParam(string? name = null)
        {

            // Validate Name
            if (string.IsNullOrEmpty(name)) // all names
            {
                if (QueryParams != null)
                {
                    QueryParams.Clear();
                }
            }
            else // single name
            {

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

            }

        } // RemoveQueryParam

        public void SetQueryParam(string name, object? value, bool bIsEncoded = false, NullValueHandling nullValueHandling = NullValueHandling.Remove)
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

                // Add *not null* Parameter
                if (value != null)
                {

                    // Convert DocumentStatusDomain
                    if (value is DateTime dt)
                    {
                        string v = String.Empty;
                        try
                        {
                            v = PandaDocUtils.DateTimeAsStringUniversalIso8601(dt);
                        }
                        catch
                        {
                            v = String.Empty;
                        }

                        _queryParams.Add(name, v, bIsEncoded, nullValueHandling);
                    }

                    // Convert DocumentStatusDomain
                    else if (value is DocumentStatusDomain domain)
                    {
                        int v = (int)DocumentStatusDomain.Unknown;

                        try
                        {
                            v = (int) domain;
                        }
                        catch
                        {
                            v = (int)DocumentStatusDomain.Unknown;
                        }

                        _queryParams.Add(name, v, bIsEncoded, nullValueHandling);
                    }

                    // No Conversaion
                    else
                    {
                        _queryParams.Add(name, value, bIsEncoded, nullValueHandling);
                    }
                }

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
                if (value is DateTime dtv)
                {
                    try
                    {
                        return PandaDocUtils.DateTimeAsStringUniversalIso8601(dtv);
                    }
                    catch
                    {
                        return String.Empty;
                    }
                }
                else
                {
                    return value.ToString()!;
                }
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

        public DocumentStatusDomain GetQueryParamDocumentStatusDomain(string name)
        {

            object? value = GetQueryParam(name);
            if (value == null)
            {
                return DocumentStatusDomain.Unknown;
            }
            else
            {

                DocumentStatusDomain status = DocumentStatusDomain.Unknown;

                try
                {
                    if (value is DocumentStatusDomain dv)
                    {
                        return dv;
                    }
                    else if (value is string sv)
                    {
                        status = PandaDocUtils.StringToDocumentStatusDomain(sv);
                    }
                    else if (value is int iv)
                    {
                        status = (DocumentStatusDomain)iv;
                    }

                    throw new NotImplementedException("Cannot Convert Type [" + typeof(ValueTask) + "] to DocumentStatusDomain --- *NOT* Implemented!");

                }
                catch
                {
                    status = DocumentStatusDomain.Unknown;
                }

                return status;

            }

        } // GetQueryParamDocumentStatusDomain

        public DateTime? GetQueryParamDateTime(string name)
        {

            object? value = GetQueryParam(name);
            if (value == null)
            {
                return null;
            }
            else
            {

                DateTime? dt;

                try
                {
                    if (value is DateTime dtv)
                    {
                        dt = dtv;
                    }
                    else if (value is string sv)
                    {
                        dt = DateTime.Parse(sv);
                    }

                    throw new NotImplementedException("Cannot Convert Type [" + typeof(ValueTask) + "] to DateTime --- *NOT* Implemented!");

                }
                catch
                {
                    dt = null;
                }

                return dt;
                
            }

        } // GetQueryParamDateTime

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
                    if (value is bool bv)
                    {
                        b = bv;
                    }
                    else if (value is int iv)
                    {
                        b = (iv != 0);
                    }
                    else if (value is string sv)
                    {
                        b = PandaDocUtils.StringAsBoolean(sv);
                    }
                    else
                    {
                        b = (bool)value;
                    }
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

        public void CloneQueryParamsFrom(PandaDocUrlQueryParams fromQueryParams)
        {

            // Clear target query params
            QueryParams.Clear();

            // Clone our query parameters over to target
            if ((fromQueryParams != null) && (fromQueryParams.QueryParams != null) && (fromQueryParams.QueryParams.Count > 0))
            {
                foreach (var (Name, Value) in fromQueryParams.QueryParams)
                {
                    QueryParams.Add(Name, Value);
                }
            }

        } // CloneQueryParamsFrom

        public void CloneQueryParamsTo(ref PandaDocUrlQueryParams toQueryParams)
        {

            if (toQueryParams.QueryParams != null)
            {

                // Clear target query params
                toQueryParams.QueryParams.Clear();

                // Clone our query parameters over to target
                if ((QueryParams != null) && (QueryParams.Count > 0))
                {
                    foreach (var (Name, Value) in QueryParams)
                    {
                        toQueryParams.QueryParams.Add(Name, Value);
                    }
                }

            }

        } // CloneQueryParamsTo

        public void CloneQueryParamsFromUrl(Url fromUrl)
        {

            // Clear target query params
            QueryParams.Clear();

            // Clone our query parameters over to target
            if ((fromUrl != null) && (fromUrl.QueryParams != null) && (fromUrl.QueryParams.Count > 0))
            {
                foreach (var (Name, Value) in fromUrl.QueryParams)
                {
                    QueryParams.Add(Name, Value);
                }
            }

        } // CloneQueryParamsFromUrl

        public void CloneQueryParamsToUrl(ref Url toUrl)
        {

            // Clear target query params
            toUrl.QueryParams.Clear();

            // Clone our query parameters over to target
            if ((QueryParams != null) && (QueryParams.Count > 0))
            {
                foreach (var (Name, Value) in QueryParams)
                {
                    toUrl.SetQueryParam(Name, Value);
                }
            }

        } // CloneQueryParamsToUrl

        protected PandaDocUrlQueryParams() // constructor
        {

        }

    } // abstract class PandaDocUrlQueryParams

} // namespace
