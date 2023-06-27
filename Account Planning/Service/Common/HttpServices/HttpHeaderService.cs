using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

using System.Collections.Generic;

namespace Com.ACSCorp.AccountPlanning.Service.Common.HttpServices
{
    public class HttpHeaderService : IHttpHeaderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpHeaderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Read(string headerKey)
        {
            if (!string.IsNullOrWhiteSpace(headerKey)
                && (_httpContextAccessor?.HttpContext?.Request?.Headers?.ContainsKey(headerKey) ?? false))
            {
                return _httpContextAccessor.HttpContext.Request.Headers[headerKey];
            }

            return string.Empty;
        }

        public Dictionary<string, string> ReadHeader(string headerKey)
        {
            return new Dictionary<string, string> {
                { headerKey, Read(headerKey)}
            };
        }

        public Dictionary<string, string> ReadAuthHeader()
        {
            return ReadHeader(HeaderNames.Authorization);
        }
    }
}