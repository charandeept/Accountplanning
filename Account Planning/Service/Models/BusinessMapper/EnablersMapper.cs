using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class EnablersMapper
    {
        public static EnablersBM GetEnablerBM(AddEnablersDTO addEnablersDTO)
        {
            return new EnablersBM()
            {
                //Id = addEnablersDTO.Id,
                CustomerId = addEnablersDTO.CustomerId,
                EnablerTypeId = addEnablersDTO.EnablerTypeId,
                Title = addEnablersDTO.Title,
                AuthorName = addEnablersDTO.AuthorName,
                Link = addEnablersDTO.Link
            };
        }

        public static AddEnablersDTO AddEnablersDTO(EnablersBM enablersBM)
        {
            return new AddEnablersDTO()
            {
                //Id = enablersBM.Id,
                CustomerId = enablersBM.CustomerId,
                EnablerTypeId = enablersBM.EnablerTypeId,
                Title = enablersBM.Title,
                AuthorName = enablersBM.AuthorName,
                Link = enablersBM.Link
            };
        }
    }
}
