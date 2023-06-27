namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ImportUsersMessageDTO
    {
        public string EmailAddress { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}