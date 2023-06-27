namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using Com.ACSCorp.AccountPlanning.Service.Repository.Models;

    public class PainPointsMapper
    {
        /*public static PainPointsDTO GetPainPointsDTO(DataRow dataRow)
        {
            return new PainPointsDTO()
            {
                Id = Convert.ToInt32(dataRow[0]),
                PainPoints = Convert.ToString(dataRow[1])
            };
        }

        public static List<PainPointsDTO> GetPainPointsDTOS(DataTable dataTable)
        {
            List<PainPointsDTO> list = new List<PainPointsDTO>();

            if (dataTable.Rows.Count == 0) { return null; }

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetPainPointsDTO(dr));
            }
            return list;
        }*/
        public static PainPointsDTO GetPainPointsDTO(DataTable PainPointsDetails)
        {
            if (PainPointsDetails.Rows.Count == 0)
            {
                return null;
            }
            return new PainPointsDTO()
            {
               // Id = Convert.ToInt32(PainPointsDetails.Rows[0][1]),
                PainPoints = Convert.ToString(PainPointsDetails.Rows[0][0])
            };
        }

       
    }
}
