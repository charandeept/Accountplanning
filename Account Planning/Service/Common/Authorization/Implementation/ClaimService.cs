using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Implementation
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public CurrentUser GetUser(string Email)
        {
            var user = _claimRepository.GetUser(Email);
            return user;
        }
    }
}
