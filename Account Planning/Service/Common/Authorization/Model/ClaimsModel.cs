using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model
{
    public class ClaimsModel
    {
        [JsonProperty("Family_Name")]
        public string FamilyName { get; set; }

        [JsonProperty("Given_Name")]
        public string GivenName { get; set; }
        public string Name { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }
    }
}
