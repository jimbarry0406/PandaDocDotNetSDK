using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleTemplateApiTest
{

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

            // scrub strSupplemental
            if (string.IsNullOrEmpty(strSupplemental))
            {
                strSupplemental = String.Empty;
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
                            listErrors.AddRange(errors);
                        }
                    }

                    // Add Current Message
                    listErrors.Add(strPreFix + ex.Message + (bRecursiveCall ? String.Empty : strSupplemental));

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

    public static class ListExtensions
    {

        internal static void DeepCopy<T>(this List<T> dest, List<T>? source)
        {

            if (
                    (source != null)
                &&  (source.Count > 0)
            )
            {
                dest.Clear();
                dest.AddRange(source);
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
                    dest.AddRange(source);
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

    internal static class ClientUtils
    {

        private static readonly string _client_setup_file = @".\client_setup.json";

        public static ClientSetup? ClientSetup { get; set; } = null;

        internal static bool LoadClientSetup()
        {

            if (!File.Exists(_client_setup_file))
            {
                // initialize default values
                ClientSetup = JsonConvert.DeserializeObject<ClientSetup>(@"{}");

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(_client_setup_file, JsonConvert.SerializeObject(ClientSetup));
            }
            else
            {
                // deserialize JSON
                ClientSetup = JsonConvert.DeserializeObject<ClientSetup>(File.ReadAllText(_client_setup_file));
            }

            return (ClientSetup != null);

        } // LoadSettings

        internal static void LogExceptions(Exception? ex, string strPreFix = "", string strSupplemental = "")
        {

            // Validate Input
            if (ex != null)
            {

                // Get Errors List
                List<string>? errors = ex.CreateErrorStringList(strPreFix, strSupplemental);

                // Validate Errors List
                if ((errors != null) && (errors.Count > 0))
                {

                    // Foreach Error
                    foreach (string error in errors)
                    {
                        LogError(error);
                    }

                } // Valid Errors List

            } // Valid Input

        } // LogExceptions

        public static void LogErrors(List<string>? errors, string strPreFixPadding = "")
        {

            // Validate Input
            if ((errors != null) && (errors.Count > 0))
            {

                // scrub prefix
                if (string.IsNullOrEmpty(strPreFixPadding))
                {
                    strPreFixPadding = String.Empty;
                }

                // log errors
                foreach (string error in errors)
                {
                    LogError(error, strPreFixPadding);
                }

            } // Valid Input

        } // LogErrors

        public static void LogError(string error = "", string strPreFixPadding = "", bool bCrLf = true)
        {

            // scrub input Input
            if (string.IsNullOrEmpty(error))
            {
                error = String.Empty;
            }

            // scrub prefix
            if (string.IsNullOrEmpty(strPreFixPadding))
            {
                strPreFixPadding = String.Empty;
            }

            // Log error
            if (bCrLf)
            {
                Console.WriteLine(strPreFixPadding + error);
            }
            else if (!string.IsNullOrWhiteSpace(strPreFixPadding) || !string.IsNullOrWhiteSpace(error))
            {
                Console.Write(strPreFixPadding + error);
            }

        } // LogErrors

    } // class ClientUtils

} // namespace
