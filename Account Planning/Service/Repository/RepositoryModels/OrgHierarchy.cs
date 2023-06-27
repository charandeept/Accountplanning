namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OrgHierarchy
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Designation { get; set; }
        public int? InfluencerKdmId { get; set; }
        public int? EngagementLevelID { get; set; }
        public int? InnovaDmid { get; set; }
        public int? ReportsToId { get; set; }
        public string LinkedInUrl { get; set; }
        public string Persona { get; set; }
        public string RoleDescription { get; set; }
        public int? CustomerId { get; set; }
        public string Gender { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual InfluencerKdm InfluencerKdm { get; set; }
        public virtual Users InnovaDm { get; set; }
        public virtual CustomerUser ReportsTo { get; set; }
    }

}
