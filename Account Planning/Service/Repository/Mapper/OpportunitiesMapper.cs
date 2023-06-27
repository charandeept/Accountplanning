using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class OpportunitiesMapper
    {

        public static OpportunitiesDTO GetOpportunitiesDTO(DataRow opportunities)
        {
            return new OpportunitiesDTO()
            {
                //OpportunitiesID = Convert.ToInt32(opportunities[0]),
                CustomerId = Convert.ToInt32(opportunities[0]),
                RoleId = Convert.ToInt32(opportunities[1]),
                //RoadMapId = Convert.ToInt32(opportunities[2]),
                RoleTitle = Convert.ToString(opportunities[2]),
                CategoryId = Convert.ToInt32(opportunities[3]),
                Category = Convert.ToString(opportunities[4]),
                NoOfRoles = Convert.ToInt32(opportunities[5]),
                Skills = Convert.ToString(opportunities[6]),
                PostedDate = Convert.ToDateTime(opportunities[7]),
                Location = Convert.ToString(opportunities[8]),
                RoleDescription = Convert.ToString(opportunities[9]),
                MinExperience = Convert.ToInt32(opportunities[11]),
                MaxExperience = Convert.ToInt32(opportunities[12]),
                IsBookMarked = Convert.ToBoolean(opportunities[10]),


            };
        }


        public static List<OpportunitiesDTO> GetOpportunitiesDTOs(DataTable opportunities)
        {
            List<OpportunitiesDTO> list = new List<OpportunitiesDTO>();
            if (opportunities.Rows.Count == 0)
            {
                return null;
            }
            foreach (DataRow op in opportunities.Rows)
            {
                list.Add(GetOpportunitiesDTO(op));
            }
            return list;
        }


        

        public static OpportunitiesDTO GetOpportunitiesDTOFromRoles(ROLES opportunities)
        {
            return new OpportunitiesDTO()
            {
                RoleId = opportunities.RoleId,
                RoleDescription = opportunities.RoleDescription,
                CustomerId = opportunities.CustomerId,
                RoleTitle=opportunities.RoleTitle,
                CategoryId = opportunities.CategoryId,
               // Category=opportunities.Category,
                NoOfRoles=opportunities.NoOfRoles,
                Skills=opportunities.Skills,
                PostedDate=opportunities.PostedDate,
                Location=opportunities.Location,
                IsBookMarked = opportunities.IsBookMarked,
                MinExperience = opportunities.MinExperience,
                MaxExperience=opportunities.MaxExperience,
                OpportunitiesId = opportunities.OpportunitiesId,


            };
        }

         public static ROLES GetOpportunities(OpportunitiesDTO opportunitiesDTO)
        {
            return new ROLES()
            {
                RoleId = opportunitiesDTO.RoleId,
                RoleDescription = opportunitiesDTO.RoleDescription,
                CustomerId = opportunitiesDTO.CustomerId,
                RoleTitle = opportunitiesDTO.RoleTitle,
                CategoryId = opportunitiesDTO.CategoryId,
                //Category = opportunitiesDTO.Category,
                NoOfRoles = opportunitiesDTO.NoOfRoles,
                Skills = opportunitiesDTO.Skills,
                PostedDate = opportunitiesDTO.PostedDate,
                Location = opportunitiesDTO.Location,
                IsBookMarked = opportunitiesDTO.IsBookMarked,
                MinExperience = opportunitiesDTO.MinExperience,
                MaxExperience = opportunitiesDTO.MaxExperience,
                OpportunitiesId=opportunitiesDTO.OpportunitiesId


            };
        }
    }
}
