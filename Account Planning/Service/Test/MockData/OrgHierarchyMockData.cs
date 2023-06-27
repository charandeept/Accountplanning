using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPlanningTest.MockData
{
    public class OrgHierarchyMockData
    {
        public static List<OrgHierarchy> GetOrgHierarchy()
        {
            return new List<OrgHierarchy>()
            {
                new OrgHierarchy()
                {
                    Id = 1,
                    UserId = 1,
                    Designation = "Managers",
                    InfluencerKdmId = 1,
                    EngagementLevelID = 3,
                    InnovaDmid = 1,
                    ReportsToId = 1,
                    LinkedInUrl = "https://www.linkedin.com/company/acs-solutions-corp/",
                    Persona = "Team Player",
                    RoleDescription = "Manages the scope of Project",
                    CustomerId = 1,
                    Gender = "Male"
                }
            };
        }

        public static List<OrgHierarchyDTO> FilterData()
        {
            return new List<OrgHierarchyDTO>()
            {
                new OrgHierarchyDTO()
                {
                   Id= 14,
                    UserId= 26,
                    Name= "Ishika",
                    InfluencerKdmId= 1,
                    EngagementLevelId= 3,
                    InnovaDmid= 5,
                    ReportsToId= 3,
                    LinkedInUrl= "",
                    Persona= "Nice person",
                    RoleDescription= "Manages Policy",
                    CustomerId= 1,
                    Gender= "Female",
                    Designation= "Manager",
                    InfluencerOrKdm_Name= "Influencer",
                    InnovaDM_Name= "Sai Kishore",
                    ReportsTO_Name= "Suresh Singh",
                    EngagementLevel_Name= "Actively Engaged",
                    UpdateBy= null,
                    //UpdatedAt= 2023-01-20,T09:29:16.863
                }
            };
        }
    }
}