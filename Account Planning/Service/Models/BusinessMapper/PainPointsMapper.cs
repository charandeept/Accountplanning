namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

   public  class PainPointsMapper
    {
        /* public static PainPointsBM GetPainPointsBM(PainPointsDTO painPointsDTO)
         {
             return new PainPointsBM()
             {
                 Id = painPointsDTO.Id,
                 PainPoints = painPointsDTO.PainPoints
             };
         }

         public static List<PainPointsBM> GetPainPointsBMS(List<PainPointsDTO> painPointsDTOS)
         {
             List<PainPointsBM> list = new List<PainPointsBM>();

             foreach (PainPointsDTO painPointsDTO in painPointsDTOS)
             {
                 list.Add(GetPainPointsBM(painPointsDTO));
             }
             return list;
         }*/

        public static PainPointsBM GetPainPointsBM(PainPointsDTO painPointsDTO)
        {
            return new PainPointsBM()
            {
                //Id = painPointsDTO.Id,
                PainPoints = painPointsDTO.PainPoints,
            };

        }
        public static PainPointsDTO GetPainpointsDTO(PainPointsBM painpointsBM)
        {
            return new PainPointsDTO()
            {
               // Id = painpointsBM.Id,
                PainPoints = painpointsBM.PainPoints
            };

        }
    }
}
