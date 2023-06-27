namespace AccountPlanningTest.MockData
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DesignationMockData
    {
        public static List<DesignationDTO> GetSample()
        {
            return new List<DesignationDTO>
            {
                new DesignationDTO
                {
                   ID=1,
                   Name="CEO"
                }
            };
        }

    }
}
