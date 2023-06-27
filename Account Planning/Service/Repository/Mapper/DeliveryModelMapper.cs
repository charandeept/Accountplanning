using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class DeliveryModelMapper
    {
        public static DeliveryModelDTO GetDeliveryModelDTO(DataRow dataRow)
        {
            return new DeliveryModelDTO()
            {
                Id = Convert.ToInt32(dataRow[0]),
                DeliveryModel = Convert.ToString(dataRow[1]) 
            };
        }


        public static List<DeliveryModelDTO> GetDeliveryModelDTOs(DataTable dataTable)
        {
            List<DeliveryModelDTO> list = new List<DeliveryModelDTO>();

            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetDeliveryModelDTO(dr));
            }
            return list;
        }
    }
}
