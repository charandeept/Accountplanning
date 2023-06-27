namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class ServiceLineMapper
    {
        public static ServiceLineDTO GetServiceLineDTO(DataRow dataRow)
        {
            return new ServiceLineDTO()
            {
                Id = Convert.ToInt32(dataRow[0]),
                ServiceLine = Convert.ToString(dataRow[1])
            };
        }


        public static List<ServiceLineDTO> GetServiceLineDTOs(DataTable dataTable)
        {
            List<ServiceLineDTO> list = new List<ServiceLineDTO>();

            if (dataTable.Rows.Count == 0) { return null; }

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetServiceLineDTO(dr));
            }
            return list;
        }
    }
}
