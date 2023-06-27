using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public SampleService()
        {
        }

        public async Task<Result<SampleDTO>> GetById(int sampleId)
        {
            try
            {
                var result = await _sampleRepository.GetById(sampleId);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<int>> AddSample(SampleDTO sampleDTO)
        {
            try
            {
                sampleDTO.CreatedById = 1;
                sampleDTO.CreatedOn = DateTime.UtcNow;

                var result = await _sampleRepository.AddSample(sampleDTO);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<int>> UpdateSample(SampleDTO sampleDTO)
        {
            try
            {
                var sample = await _sampleRepository.GetById(sampleDTO.Id);
                if (sample == null)
                {
                    return Result.Fail<int>("Sample not found");
                }

                sample.Name = sampleDTO.Name;
                sample.IsActive = sampleDTO.IsActive;
                sample.ModifiedById = 1;
                sample.ModifiedOn = DateTime.UtcNow;

                var result = await _sampleRepository.UpdateSample(sample);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}