using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CSATDetailsMapper
    {
        public static CSATDetailsBM GetCSATDetailsBM (CSATDetailsDTO CSATDetailsDTO)
        {
            return new CSATDetailsBM()
            {
                CSATNumber = CSATDetailsDTO.CSATNumber,
                Comments = CSATDetailsDTO.Comments,
            };

        }


        public static CSATDetailsDTO GetCSATDetailsDTO(CSATDetailsBM CSATDetailsBM)
        {
            return new CSATDetailsDTO()
            {
                CSATNumber = CSATDetailsBM.CSATNumber,
                Comments = CSATDetailsBM.Comments
            };

        }

        
    }
}
