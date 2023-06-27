using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels
{
    public class CustomerQuestionnaire
    {

        public int Id { get; set; }
        
        public int QuestionId { get; set; }

        public int CustomerId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Points { get; set; }

    }
}
