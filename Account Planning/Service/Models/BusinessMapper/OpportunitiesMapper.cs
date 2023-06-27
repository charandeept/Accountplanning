using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class OpportunitiesMapper
    {
        public static OpportunitiesBM GetOpportunitiesBM(OpportunitiesDTO opportunitiesDTO)
        {
            return new OpportunitiesBM()
            {
                RoleId=opportunitiesDTO.RoleId,
                CustomerId = opportunitiesDTO.CustomerId,
              //  RoadMapId = opportunitiesDTO.RoadMapId,
                RoleTitle = opportunitiesDTO.RoleTitle,
                CategoryId = opportunitiesDTO.CategoryId,
                //Category = opportunitiesDTO.Category,
                NoOfRoles = opportunitiesDTO.NoOfRoles,
                Skills = opportunitiesDTO.Skills,
                PostedDate = opportunitiesDTO.PostedDate,
                Location = opportunitiesDTO.Location,
                RoleDescription = opportunitiesDTO.RoleDescription,
                IsBookMarked = opportunitiesDTO.IsBookMarked,
                MinExperience = opportunitiesDTO.MinExperience,
                MaxExperience = opportunitiesDTO.MaxExperience,
                OpportunitiesId = opportunitiesDTO.OpportunitiesId,





            };
        }

        public static List<OpportunitiesBM> GetOpportunitiesBMs(List<OpportunitiesDTO> opportunitiesDTOs)
        {
            List<OpportunitiesBM> list = new List<OpportunitiesBM>();

            foreach (OpportunitiesDTO opportunitiesDTO in opportunitiesDTOs)
            {
                list.Add(GetOpportunitiesBM(opportunitiesDTO));
            }
            return list;
        }


        public static OpportunitiesDTO GetOpportunitiesDTO(OpportunitiesBM opportunitiesBM)
        {
            return new OpportunitiesDTO()
            {
                RoleDescription = opportunitiesBM.RoleDescription,
                RoleId = opportunitiesBM.RoleId,
                //OpportunitiesId = opportunitiesBM.OpportunitiesId,
                CustomerId = opportunitiesBM.CustomerId,
                RoleTitle = opportunitiesBM.RoleTitle,
                CategoryId = opportunitiesBM.CategoryId,
                //Category = opportunitiesBM.Category,
                NoOfRoles = opportunitiesBM.NoOfRoles,
                Skills = opportunitiesBM.Skills,
                PostedDate = opportunitiesBM.PostedDate,
                Location = opportunitiesBM.Location,
                IsBookMarked = opportunitiesBM.IsBookMarked,
                MinExperience = opportunitiesBM.MinExperience,
                MaxExperience = opportunitiesBM.MaxExperience,
                OpportunitiesId=opportunitiesBM.OpportunitiesId,


            };
        }
    }
}
