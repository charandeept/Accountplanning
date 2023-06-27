using System.Collections.Generic;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Models
{
    public class ListResult<TEntity> where TEntity : class
    {
        public List<TEntity> Items { get; set; }
        public int Total { get; set; }
    }
}