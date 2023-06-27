using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;

using System;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class SampleRepository : BaseRepository<Sample>, ISampleRepository
    {
        public SampleRepository(SampleContext dbContext) : base(dbContext)
        {
        }

        public Task<int> AddSample(SampleDTO sample)
        {
            throw new NotImplementedException();
        }

        public Task<SampleDTO> GetById(int sampleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateSample(SampleDTO sample)
        {
            throw new NotImplementedException();
        }
    }
}