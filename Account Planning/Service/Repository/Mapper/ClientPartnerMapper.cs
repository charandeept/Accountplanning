using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class ClientPartnerMapper
    {
        public static ClientPartnerDTO GetClientPartnerDTO(DataRow dataRow)
        {
            return new ClientPartnerDTO()
            {
                Id = Convert.ToInt32(dataRow[0]),
                ClientPartner = Convert.ToString(dataRow[1])
            };
        }


        public static List<ClientPartnerDTO> GetClientPartnerDTOs(DataTable dataTable)
        {

            List<ClientPartnerDTO> list = new List<ClientPartnerDTO>();

            if(dataTable.Rows.Count == 0 )
            {
                return null;
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetClientPartnerDTO(dr));
            }
            return list;
        }
    }
}
