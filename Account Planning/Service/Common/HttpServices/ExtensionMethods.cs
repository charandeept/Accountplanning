using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.HttpServices
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Append headers.
        /// </summary>
        /// <param name="httpRequestMessage"></param>
        /// <param name="headers"></param>
        public static void AppendHeaders(this HttpRequestMessage httpRequestMessage, IDictionary<string, string> headers)
        {
            if (headers != null && headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    httpRequestMessage.Headers.Add(header.Key, header.Value);
                }
            }
        }

        public static string AppendQueryParameters(this string url, IDictionary<string, string> queryParams)
        {
            string urlWithQueryParams = url;

            if (queryParams != null && queryParams.Count > 0)
            {
                StringBuilder query = new StringBuilder();
                query.Append(url);
                query.Append('?');

                List<string> keys = queryParams.Keys.ToList();

                for (int i = 0; i < keys.Count; i++)
                {
                    query.Append(Uri.EscapeDataString(keys[i]));
                    query.Append("=");
                    query.Append(queryParams[keys[i]]);
                    if (i != keys.Count - 1)
                    {
                        query.Append("&");
                    }
                }

                urlWithQueryParams = query.ToString();
            }
            return urlWithQueryParams;
        }
    }
}