using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System.Collections.Generic;

namespace AccountPlanningTest.MockData
{
    public class InfluencerMockData
    {
        public static List<InfluencerKdm> GetInfluencerData()
        {
            return new List<InfluencerKdm>
            {
                new InfluencerKdm
                {
                    Id=1,
                    Name="INFULENCER"
                },
                new InfluencerKdm
                {
                    Id=2,
                    Name="KDM"
                },
            };
        }
    }
}
