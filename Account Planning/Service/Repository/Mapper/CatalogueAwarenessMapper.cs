using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CatalogueAwarenessMapper
    {
        public static CatalogueAwarenessDTO GetCatalogueAwarenessDTO(DataTable CatalogueAwareness)
        {
            return new CatalogueAwarenessDTO()
            {
               

            };
        }

        public static CatalogueAwareness GetCatalogueAwareness(CatalogueAwarenessDTO catalogueAwarenessDTO)
        {
            return new CatalogueAwareness()
            {
                
            };
        }
    }
}
