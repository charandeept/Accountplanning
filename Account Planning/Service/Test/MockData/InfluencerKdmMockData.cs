using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPlanningTest.MockData
{
    public class InfluencerKdmMockData
    {
        public static List<InfluencerKdm> GetInfluencerKdm()
        {
            return new List<InfluencerKdm>()
            {
                new InfluencerKdm()
                {
                    Id=1,
                    Name="Influencer"
                },
                new InfluencerKdm()
                {
                    Id=2,
                    Name="KDM"
                }
            };
        }
    }
}
