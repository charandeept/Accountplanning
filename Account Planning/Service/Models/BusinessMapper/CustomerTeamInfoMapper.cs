using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerTeamInfoMapper
    {
        public static CustomerTeamInfoDTO GetCustomerTeamInfoDTO (CustomerTeamInfoBM customerTeamInfoBM)
        {
            return new CustomerTeamInfoDTO()
            {
               // ClientPartner=customerTeamInfoBM.ClientPartner,
                DeliveryManager=customerTeamInfoBM.DeliveryManager,
                DeliveryModel=customerTeamInfoBM.DeliveryModel,
                ClientPartnerName=customerTeamInfoBM.ClientPartnerName,
                OnshoreResources=customerTeamInfoBM.OnshoreResources,
                OffshoreResources=customerTeamInfoBM.OffshoreResources,
                NearShore =customerTeamInfoBM.NearShore,   
            };
        }

        public static CustomerTeamInfoBM GetCustomerTeamInfoBM (CustomerTeamInfoDTO customerTeamInfoDTO)
        {
            return new CustomerTeamInfoBM()
            {
                //ClientPartner = customerTeamInfoDTO.ClientPartner,
                DeliveryManager = customerTeamInfoDTO.DeliveryManager,
                DeliveryModel = customerTeamInfoDTO.DeliveryModel,
                ClientPartnerName = customerTeamInfoDTO.ClientPartnerName,
                OnshoreResources = customerTeamInfoDTO.OnshoreResources,
                OffshoreResources = customerTeamInfoDTO.OffshoreResources,
                NearShore = customerTeamInfoDTO.NearShore,
            };
        }
    }
}

