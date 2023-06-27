namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OrgHierarchyDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public int? InfluencerKdmId { get; set; }
        public int? EngagementLevelId { get; set; }
        public int? InnovaDmid { get; set; }
        public int? ReportsToId { get; set; }
        public string LinkedInUrl { get; set; }
        public string Persona { get; set; }
        public string RoleDescription { get; set; }
        public int? CustomerId { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public string? InfluencerOrKdm_Name { get; set; }
        public string InnovaDM_Name { get; set; }
        public string? ReportsTO_Name { get; set; }
        public string? EngagementLevel_Name { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}