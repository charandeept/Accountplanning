namespace AccountPlanningTest.MockData
{
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InnovaUserMockData
    {
        public static List<InnovaUserDTO> GetSample()
        {
            return new List<InnovaUserDTO>
            {
                new InnovaUserDTO
                {
                   ID=1,
                   Name="Nikkila"
                }
            };
        }

    }
}
