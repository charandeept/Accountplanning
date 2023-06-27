using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels
{
    public class FinancialHealthHealthIndicator
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int questionId { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
    }
}
