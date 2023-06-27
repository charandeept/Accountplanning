namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EnablerTypeMapper
    {
        public static EnablerTypeDTO GetEnablersDTOFromEnablerTypeTable(EnablerType enablerType)
        {
            return new EnablerTypeDTO()
            {
                //ID=enablerType.Id,
                Title = enablerType.Title
            };
        }
        public static EnablerType GetEnablerTypeTable(EnablerTypeDTO enablersDTO)
        {
            return new EnablerType()
            {
                Title = enablersDTO.Title,
                // Id = enablersDTO.ID
            };
        }
        public static EnablerTypeBM GetEnablersBMFromEnablersDTO(EnablerTypeDTO enablerDTO)
        {
            return new EnablerTypeBM()
            {
                //ID = enablerType.ID,
                Title = enablerDTO.Title
            };
        }
        public static EnablerTypeDTO GetEnablersDTOFromEnablersBM(EnablerTypeBM enablerBM)
        {
            return new EnablerTypeDTO()
            {
                //ID = enablerType.ID,
                Title = enablerBM.Title
            };
        }
    }
}
