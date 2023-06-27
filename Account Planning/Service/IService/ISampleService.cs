using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface ISampleService
    {
        public Task<Result<SampleDTO>> GetById(int sampleId);

        public Task<Result<int>> AddSample(SampleDTO sample);

        public Task<Result<int>> UpdateSample(SampleDTO sample);
    }
}