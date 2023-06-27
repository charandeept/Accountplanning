namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EnablersModelMapper
    {
        public static AddEnablersDTO GetEnablersDTO(Enablers enablers)
        {
            return new AddEnablersDTO()
            {
                //Id = enablers.Id,
                CustomerId = enablers.CustomerId,
                EnablerTypeId = enablers.EnablerTypeId,
                Title = enablers.Title,
                AuthorName = enablers.AuthorName,
                Link = enablers.Link
            };
        }

        public static Enablers GetEnablersDetails(AddEnablersDTO addenablersDTO)
        {
            return new Enablers()
            {
                //Id = addenablersDTO.Id,
                CustomerId = addenablersDTO.CustomerId,
                EnablerTypeId = addenablersDTO.EnablerTypeId,
                Title = addenablersDTO.Title,
                AuthorName = addenablersDTO.AuthorName,
                Link = addenablersDTO.Link
            };
        }
    }
}
