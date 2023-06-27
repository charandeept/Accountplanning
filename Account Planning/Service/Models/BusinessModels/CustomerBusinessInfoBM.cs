using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class CustomerBusinessInfoBM
    {
        // public string Overview { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Website { get; set; }

        public int IndustryId { get; set; }

        public string IndustryName { get; set; }

        public int CompanySize { get; set; }

        public string HeadQuarters { get; set; }

        public string Speciality { get; set; }

        public string ServicesOffered { get; set; }

        public string TechStack { get; set; }
        public int TimeZoneId { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? ProjectEndDate { get; set; }
    }
}
