using System.Collections.Generic;

namespace Com.ACSCorp.AccountPlanning.Service.Common.HttpServices
{
    public interface IHttpHeaderService
    {
        public string Read(string headerKey);

        public Dictionary<string, string> ReadHeader(string headerKey);

        public Dictionary<string, string> ReadAuthHeader();
    }
}