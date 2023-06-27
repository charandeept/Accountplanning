namespace AccountPlanningTest.MockData
{
    using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EnablersMockData
    {
        public static EnablerDTO EnablerData()
        {
            EnablerDTO enablers = new EnablerDTO();
            var enabler = new Enabler()
            {
                Id = 1,
                CustomerId = 1,
                EnablerTypeId = 2,
                Title = "Java Developer",
                AuthorName = "Akish",
                Link = "www.akish.com"

            };
            enablers.Enablers.Add(enabler);
            var count = new CountOfEnabler()
            {
                EnablerTypeId = 1,
                EnablerTitle = "Best Pratices",
                Count = 6
            };
            enablers.Count.Add(count);
            return enablers;

        }
        public static EnablersBM addEnablers()
        {
            return new EnablersBM()
            {
                CustomerId = 1,
                EnablerTypeId = 2,
                Title = "Java",
                AuthorName = "Akish",
                Link = "www.akish.com"
            };
        }

        public static EnablerTypeBM CreateEnabler()
        {
            return new EnablerTypeBM()
            {
                Title = "string"
            };
        }
        public static bool RemoveEnabler()
        {
            new EnablerTypeDTO()
            {
                Title = "string"
            };
            return true;
        }
        public static bool RemoveEnablerCard()
        {
            new EnablerCardDTO()
            {
                Title = "string",
                CustomerId = 1,
                EnablerTypeId = 2,
                AuthorName = "ronaldo",
                Link = "www.ronaldo.com",
            };
            return true;
        }
    }
}
