using System.Net;

namespace Com.ACSCorp.AccountPlanning.Service.Common.HttpServices.Models
{
    public class HttpResponseModel
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Response { get; set; }
    }
}