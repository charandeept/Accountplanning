using Com.ACSCorp.AccountPlanning.Service.Repository.Models;

using Microsoft.EntityFrameworkCore;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Context
{
    public partial class SampleContext : DbContext
    {
        public SampleContext()
        {
        }

        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sample> Client { get; set; }
    }
}