using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class ClientDetailsMapper
    {
        public static ClientDetailsBM GetClientDetailsBM(ClientDetailsDTO clientDetailsDTO)
        {
            if(clientDetailsDTO == null)
            {
                return new ClientDetailsBM();
            }
            return new ClientDetailsBM()
            {
               // ClientPartnerId = clientDetailsDTO.ClientPartnerId,
                ClientPartnerName = clientDetailsDTO.ClientPartnerName,
                DeliveryManagerId = clientDetailsDTO.DeliveryManagerId,
                DeliveryManager = clientDetailsDTO.DeliveryManager,
                DeliveryModel = clientDetailsDTO.DeliveryModel,
                TimeZoneId = clientDetailsDTO.TimeZoneId,
                Timezone = clientDetailsDTO.Timezone,
                OnshoreResources = clientDetailsDTO.OnshoreResources,
                OffshoreResources = clientDetailsDTO.OffshoreResources,
                NearShore = clientDetailsDTO.NearShore,
                ProjectEndDate = clientDetailsDTO.ProjectEndDate,


            };
        }
    }
}
