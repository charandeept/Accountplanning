using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CatalogueAwarenessMapper
    {
        public static CatalogueAwarenessBM GetCatalogueAwarenessBMs(CatalogueAwarenessDTO catalogueAwarenessDTO)
        {
            return new CatalogueAwarenessBM()
            {
               // CustomerId = .CustomerId,

            };
        }

        public static CatalogueAwarenessDTO GetCatalogueAwarenessDTOs(CatalogueAwarenessBM catalogueAwarenessBM)
        {
            return new CatalogueAwarenessDTO()
            {
               // CustomerId = .CustomerId,
            };
        }
    }
}
