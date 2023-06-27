using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using Com.ACSCorp.AccountPlanning.Service.Common.HttpServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly LoginSettings settings = new LoginSettings();
        private readonly IHttpService _httpService;

        public TokenService(IHttpServiceFactory httpServiceFactory,
            IConfiguration configuration)
        {
            _httpService = httpServiceFactory.CreateHttpService();

            configuration.Bind("LoginSettings", settings);
        }

        /// <summary>
        /// Is Token Authorized
        /// </summary>
        /// <param name="token"></param> 
        /// <returns></returns>
        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            var queryParams = new Dictionary<string, string>()
            {
                {"token",  token}
            };

            return _httpService.GetWithQueryParamsAsync<bool>(settings.TokenValidationUrl, queryParams).Result;
        }

        /// <summary>
        /// Get user details as claims
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsModel GetUserClaims(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }

            var queryParams = new Dictionary<string, string>()
            {
                {"token",  token}
            };

            return _httpService.GetWithQueryParamsAsync<ClaimsModel>(settings.TokenClaimsUrl, queryParams).Result;
        }
    }
}
