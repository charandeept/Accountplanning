using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
    public class CustomerInfoTable
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Website { get; set; }
        public int IndustryId { get; set; }
        public int CompanySize { get; set; }
        public string HeadQuarters { get; set; }
        public string Speciality { get; set; }
        public string TechStack { get; set; }
        public string ServicesOffered { get; set; }
        public int TimeZoneId { get; set; }
        public int CSAT { get; set; }
        public string CSATComments { get; set; }
        public int CustomerMood { get; set; }
        public int EngagementHealth { get; set; }
        public int FinancialHealth { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public DateTime? ProjectEndDate { get; set; }


        // public string ClientPartner { get; set; }
        // public string DeliveryManager { get; set; }
        // public string DeliveryModel { get; set; }
        // public string Timezone { get; set; }
        // public int OnshoreResources { get; set; }
        // public int OffshoreResources { get; set; }
        // public int NearShore { get; set; }

    }
}
