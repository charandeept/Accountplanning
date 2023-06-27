using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class RoadMapDetailsMapper
    {

        public static RoadMapDetailsBM GetRoadMapDetailsBM(RoadMapDetailsDTO roadMapDetailsDTO)
        {
            return new RoadMapDetailsBM()
            {
                Id = roadMapDetailsDTO.Id,
                CustomerId = roadMapDetailsDTO.CustomerId,
                Description = roadMapDetailsDTO.Description,
                Image = roadMapDetailsDTO.Image,
            };
        }

        public static RoadMapDetailsDTO GetRoadMapDetailsDTO(RoadMapDetailsBM roadMapDetailsBM)
        {
            return new RoadMapDetailsDTO()
            {
                Id = roadMapDetailsBM.Id,
                CustomerId = roadMapDetailsBM.CustomerId,
                Description = roadMapDetailsBM.Description,
                Image=roadMapDetailsBM.Image,
            };
        }


    }
}
