using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface ISampleRepository : IBaseRepository
    {
        public Task<SampleDTO> GetById(int sampleId);

        public Task<int> AddSample(SampleDTO sample);

        public Task<int> UpdateSample(SampleDTO sample);
    }
}