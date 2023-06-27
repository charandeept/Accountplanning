using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class DeliveryManagerMapper
    {
        public static DeliveryManagerDTO GetDeliveryManagerDTO(DataRow dataRow)
        {
            return new DeliveryManagerDTO() 
            { 
                Id = Convert.ToInt32(dataRow[0]),
                DeliveryManager = Convert.ToString(dataRow[1]) };
        }


        public static List<DeliveryManagerDTO> GetDeliveryManagerDTOs(DataTable dataTable)
        {
            List<DeliveryManagerDTO> list = new List<DeliveryManagerDTO>();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetDeliveryManagerDTO(dr));
            }
            return list;
        }
    }
}
