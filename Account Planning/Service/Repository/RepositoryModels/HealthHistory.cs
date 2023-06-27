namespace Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels
{
   
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class HealthHistory
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int HealthTypeId { get; set; }
        public int HealthValue { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
    enum HealthType
    {
        EngagementHealth = 1,
        FinancialHealth
    }
}
