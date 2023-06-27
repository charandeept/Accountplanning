using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPlanningTest.MockData
{
    public class EngagementMockData
    {
        public static List<Engagement> GetEngagementData()
        {
            return new List<Engagement>
            {
                new Engagement
                {
                    ID=1,
                    Name="Not Engaged"
                },
                new Engagement
                {
                    ID=2,
                    Name="Partially Engaged"
                },
                new Engagement
                {
                    ID=3,
                    Name="Actively Engaged"
                },
            };
        }
    }
}