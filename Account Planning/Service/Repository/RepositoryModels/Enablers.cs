using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels
{
    public class Enablers
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EnablerTypeId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Link { get; set; }
    }
}
