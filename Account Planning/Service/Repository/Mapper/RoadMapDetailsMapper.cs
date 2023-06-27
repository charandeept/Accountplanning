using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class RoadMapDetailsMapper
    {
        public static RoadMapDetailsDTO GetRoadMapDetailsDTO(RoadMapDetails roadMapDetails)
        {
            return new RoadMapDetailsDTO()
            {
                Id = roadMapDetails.Id,
                CustomerId = roadMapDetails.CustomerId,
                Description = roadMapDetails.Description,
                Image = roadMapDetails.Image,
            };
        }

        public static RoadMapDetails GetRoadMapDetails(RoadMapDetailsDTO roadMapDetailsDTO)
        {
            return new RoadMapDetails()
        {
                Id = roadMapDetailsDTO.Id,
                CustomerId = roadMapDetailsDTO.CustomerId,
                Description = roadMapDetailsDTO.Description,
                Image=roadMapDetailsDTO.Image,
            };
        }
    }
}
