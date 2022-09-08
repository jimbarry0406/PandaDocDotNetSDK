//
// Internal Utils, only for use within the local library code, will not be accessible by client code
//

using System;
using System.Collections.Generic;

namespace PandaDocDotNetSDK
{

    //
    // Interfaces
    //

    internal interface IHasStringName
    {
        string? Name { get; }
    }

    internal interface IHasObjectValue
    {
        object Value { get; }
    }

    //
    // Class Extensions
    //

    internal static class ExceptionExtensions
    {

        internal static List<string>? CreateErrorStringList(this Exception ex, string strPreFix = "", string strSupplemental = "", bool bRecursiveCall = false)
        {

            // preserve input
            string strOrigPrefix = strPreFix;
            string strOrigSupplemental = strSupplemental;

            // scrub prefix
            if (string.IsNullOrEmpty(strPreFix))
            {
                strPreFix = "Exception:";
            }
            if (!strPreFix.EndsWith(":"))
            {
                strPreFix += ":";
            }

            // scrub supl
            if (string.IsNullOrEmpty(strSupplemental))
            {
                strSupplemental = string.Empty;
            }
            else // if (!string.IsNullOrEmpty(strSupplemental))
            {
                strSupplemental = @" <<" + strSupplemental + @">>";
            }

            // Validate new List
            List<string>? listErrors = new List<string>();
            if (listErrors != null)
            {

                // Validate Exception
                if (ex != null)
                {

                    // Recursively Gather Errors from Inner Exception(s)
                    if (ex.InnerException != null)
                    {
                        List<string>? errors = ex.InnerException.CreateErrorStringList(strOrigPrefix, strOrigSupplemental, bRecursiveCall: true);
                        if ((errors != null) && (errors.Count > 0))
                        {
                            listErrors.Append<string>(errors);
                        }
                    }

                    // Add Current Message
                    listErrors.Add(strPreFix + ex.Message + (bRecursiveCall ? string.Empty : strSupplemental));

                    // For our Root/Top-Level Call (not-recursive) --- Add a Full StackTrace
                    if (!bRecursiveCall && !string.IsNullOrEmpty(ex.StackTrace))
                    {
                        listErrors.Add("Stack-Trace:" + ex.StackTrace);
                    }

                } // Valid Exception

            } // Valid list

            return listErrors;

        } // CreateErrorStringList

    } // class ExceptionExtensions

    internal static class ListExtensions
    {

        internal static void Append<T>(this List<T> dest, List<T>? source)
        {

            if (
                    (source != null)
                &&  (source.Count > 0)
            )
            {
                foreach (T item in source)
                {
                    dest.Add(item);
                }
            }

        } // Append

        internal static void DeepCopy<T>(this List<T> dest, List<T>? source)
        {

            if (
                    (source != null)
                &&  (source.Count > 0)
            )
            {
                dest.Clear();
                dest.Append<T>(source);
            }

        } // DeepCopy

        internal static List<T>? CreateDeepCopy<T>(this List<T> source)
        {

            List<T>? dest = new List<T>();

            try
            {
                if (
                        (dest != null)
                    &&  (source != null)
                    &&  (source.Count > 0)
                )
                {
                    dest.Append<T>(source);
                }
            }
            catch
            {
                dest = null;
            }

            return dest;

        } // CreateDeepCopy

    } // class List Extensions

    //
    // Classes
    //

    internal static class InternalApiUtils
    {

        internal static T[]? ArrayCreateDeepCopy<T>(T[]? source)
        {

            T[]? dest = null;

            if ((source != null) && (source.Length > 0))
            {

                try
                {
                    dest = new T[source.Length];
                    if (dest != null)
                    {
                        int index = 0;
                        foreach (T item in source)
                        {
                            dest.SetValue(item, index++);
                        }
                    }
                }
                catch
                {
                    dest = null;
                }

            } // source != null

            return dest;

        } // ArrayCreateDeepCopy

        internal static object? FindArrayElementValue<T>(T[]? array, Predicate<T>? match, object? defaultValue = null) where T : IHasStringName, IHasObjectValue
        {

            object? value = null;

            // Attempt Work..
            try
            {

                // Validate Input
                if ((array != null) && (array.Length > 0) && (match != null))
                {

                    // Find Match
                    T? instance = Array.Find<T>(array, match);
                    if (instance != null)
                    {
                        value = instance.Value;
                    }

                    // Assign Default for null or Empty
                    if (defaultValue != null)
                    {

                        if (value == null)
                        {
                            value = defaultValue;
                        }
                        else // if (value != null)
                        {
                            Type objectType = value.GetType();
                            if ((objectType == typeof(string)) || (objectType == typeof(String)))
                            {
                                if (string.IsNullOrEmpty(value.ToString()))
                                {
                                    value = string.IsNullOrEmpty(defaultValue.ToString()) ? string.Empty : defaultValue.ToString();
                                }
                            }
                        }

                    } // defaultValue != null

                } // Valid Input

                // Final Answer
                return value;

            }
            catch // best efforts, return null on exception
            {
                return null;
            }

        } // FindArrayElementValue

    } // class ApiUtils

} // namespace PandaDocDotNetSDK
