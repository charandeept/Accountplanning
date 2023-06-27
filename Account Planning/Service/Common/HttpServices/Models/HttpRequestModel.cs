using System.Collections.Generic;
using System.Net.Http;

namespace Com.ACSCorp.AccountPlanning.Service.Common.HttpServices.Models
{
    public class HttpRequestModel
    {
        public string RequestUrl { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public HttpContent HttpContent { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IDictionary<string, string> QueryParameters { get; set; }
    }
}