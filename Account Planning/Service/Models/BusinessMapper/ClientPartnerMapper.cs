using System;
using System.Collections.Generic;
using System.Text;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
   
    public class ClientPartnerMapper
    {
        public static ClientPartnerBM GetClientPartnerBM(ClientPartnerDTO clientPartnerDTO)
        {
            return new ClientPartnerBM()
            {
                Id = clientPartnerDTO.Id,
                ClientPartner = clientPartnerDTO.ClientPartner
            };
        }

        public static List<ClientPartnerBM> GetClientPartnerBMs(List<ClientPartnerDTO> clientPartnerDTOs)
        {
            List<ClientPartnerBM> list = new List<ClientPartnerBM>();

            foreach (ClientPartnerDTO clientPartnerDTO in clientPartnerDTOs)
            {
                list.Add(GetClientPartnerBM(clientPartnerDTO));
            }
            return list;
        }
    }
}
