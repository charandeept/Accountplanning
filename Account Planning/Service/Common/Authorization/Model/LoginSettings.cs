using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model
{
    public class LoginSettings
    {
        public long ClientUId { get; set; }
        public string TokenValidationUrl { get; set; }
        public string TokenClaimsUrl { get; set; }

    }
}
