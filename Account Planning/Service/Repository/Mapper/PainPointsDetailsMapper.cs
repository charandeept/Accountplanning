using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class PainPointsDetailsMapper
    {
        public static PainPointsDetailsDTO GetPainPointsDetailsDTO(OpportunitiesTable opportunitiesTable)
        {
            return new PainPointsDetailsDTO()
            {
                PainPoints = opportunitiesTable.PainPoints,
            };
        }

        public static PainPointsDetails GetPainPointsDetails(PainPointsDetailsDTO painPointsDetailsDTO)
        {
            return new PainPointsDetails()
            {
                PainPoints = painPointsDetailsDTO.PainPoints
            };
        }
    }
}
