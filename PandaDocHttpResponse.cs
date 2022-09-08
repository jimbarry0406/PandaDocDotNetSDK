using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace PandaDocDotNetSDK
{
    public class PandaDocHttpResponse
    {

        public HttpResponseHeaders? Headers { get; set; }
        public string? Content { get; set; }
        public HttpResponseMessage? HttpResponse { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public void ExtractContentErrors(string responseContent)
        {

            // Validate Input
            if (!string.IsNullOrEmpty(responseContent))
            {

                if (responseContent.StartsWith("<html"))
                {

                    // Attempt to Deserialize Html, Best Efforts
                    string text = String.Empty;
                    try
                    {

                        HtmlDocument doc = new();
                        if (doc != null)
                        {
                            doc.LoadHtml(responseContent);
                            if (doc.DocumentNode != null)
                            {
                                HtmlNode node = doc.DocumentNode.SelectSingleNode("//body");
                                if (node != null)
                                {
                                    text = node.InnerText;
                                }
                            }
                        }

                    }
                    catch
                    {
                        text = String.Empty;
                    }

                    // Validate Deserialization
                    if (!string.IsNullOrEmpty(text))
                    {

                        // Remove Whitespace
                        text = Regex.Replace(text, @"\s+", " ");
                        if (!string.IsNullOrEmpty(text))
                        {
                            text = text.Trim();
                        }

                        // Anything Left?
                        if (!string.IsNullOrEmpty(text))
                        {
                            Errors.Add("HTML Exception:" + text);
                        }

                    } // text != null

                }
                else
                {

                    // Attempt Error Deserialization, Best Efforts
                    Dictionary<string, dynamic>? errorDictionary = null;
                    try
                    {
                        errorDictionary = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseContent);
                    }
                    catch
                    {
                        errorDictionary = null;
                    }

                    // Validate Deserialization
                    if (errorDictionary != null)
                    {

                        if (errorDictionary.ContainsKey("type"))
                        {

                            // Type
                            string errorType = errorDictionary["type"];
                            if (string.IsNullOrEmpty(errorType))
                            {
                                errorType = "Uknown";
                            }

                            // Details...
                            if (errorDictionary.ContainsKey("info_message"))
                            {
                                string info_message = errorDictionary["info_message"];
                                if (!string.IsNullOrEmpty(info_message))
                                {
                                    Errors.Add(errorType + ":" + info_message);
                                }
                            }

                            if (errorDictionary.ContainsKey("detail"))
                            {
                                string detail = errorDictionary["detail"];
                                if (!string.IsNullOrEmpty(detail))
                                {
                                    Errors.Add(errorType + ":" + detail);
                                }
                            }

                            if (errorDictionary.ContainsKey("details"))
                            {
                                string errorDetails = errorDictionary["details"];
                                if (!string.IsNullOrEmpty(errorDetails))
                                {
                                    Errors.Add(errorType + ":" + errorDetails);
                                }
                            }

                        } // contains "type"

                    } // errorDictionary != null

                } // try/catch

            } // Valid Input

        } // Extract Errors

    } // class PandaDocHttpResponse

    public class PandaDocHttpResponse<T> : PandaDocHttpResponse
    {

        public T? Value { get; set; }

    } // class PandaDocHttpResponse<T>

} // namespace PandaDocDotNetSDK