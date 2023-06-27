using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Data;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerTeamInfoMapper
    {
        public static ClientDetailsDTO GetCustomerTeamInfoDTO(DataTable customerTeamInfo)
        {
            if(customerTeamInfo.Rows.Count == 0)
            {
                return null;
            }

            return new ClientDetailsDTO()
            {
                // Overview = Convert.ToString(customerTeamInfo.Rows[0][0]
                //ClientPartnerName =Convert.ToString(customerTeamInfo),
                ClientPartnerName = Convert.ToString(customerTeamInfo.Rows[0][0]),
               // ClientPartnerId = Convert.ToInt32(customerTeamInfo.Rows[0][0]),
                DeliveryManagerId = Convert.ToInt32(customerTeamInfo.Rows[0][1]),
                DeliveryManager = Convert.ToString(customerTeamInfo.Rows[0][2]),
                DeliveryModel = Convert.ToString(customerTeamInfo.Rows[0][3]),
                TimeZoneId = (int)customerTeamInfo.Rows[0][4],
                Timezone = Convert.ToString(customerTeamInfo.Rows[0][5]),
                OnshoreResources = Convert.ToInt32(customerTeamInfo.Rows[0][6]),
                OffshoreResources = Convert.ToInt32(customerTeamInfo.Rows[0][7]),
                NearShore = Convert.ToInt32(customerTeamInfo.Rows[0][8]),
                ProjectEndDate = Convert.ToString(customerTeamInfo.Rows[0][9])
                
            };
        }
        public static CustomerTeamInfoDTO GetCustomerTeamInfoDTOFromCustomerTable(CustomerTeamInfo customerTeamInfo)
        {
            return new CustomerTeamInfoDTO()
            {
                //ClientPartner = customerTeamInfo.ClientPartnerId,
                DeliveryManager = customerTeamInfo.DeliveryManagerId,
                DeliveryModel = customerTeamInfo.DeliveryModel,
                ClientPartnerName = customerTeamInfo.ClientPartnerName,
                //Timezone = customerTeamInfo.Timezone,
                OnshoreResources = customerTeamInfo.OnshoreResources,
                OffshoreResources = customerTeamInfo.OffshoreResources,
                NearShore = customerTeamInfo.NearShoreResources
            };
        }


        public static CustomerTeamInfo GetCustomerTeamInfo(CustomerTeamInfoDTO customerTeamInfoDTO)
        {
            return new CustomerTeamInfo()
            {
                //ClientPartnerId = customerTeamInfoDTO.ClientPartner,
                DeliveryManagerId = customerTeamInfoDTO.DeliveryManager,
                DeliveryModel = customerTeamInfoDTO.DeliveryModel,
                ClientPartnerName= customerTeamInfoDTO.ClientPartnerName,
                //Timezone = customerTeamInfo.Timezone,
                OnshoreResources = customerTeamInfoDTO.OnshoreResources,
                OffshoreResources = customerTeamInfoDTO.OffshoreResources,
                NearShoreResources = customerTeamInfoDTO.NearShore
            };
        }


    }
}
