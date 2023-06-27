using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class EnablerService : IEnablerService
    {
        private readonly IEnablerRepository _enablerRepository;
        public EnablerService(IEnablerRepository enablerRepository)
        {
            _enablerRepository = enablerRepository;
        }

        public async Task<Result<EnablerDTO>> GetEnablers()
        {
            try
            {
                var result = await _enablerRepository.GetEnablers();
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<EnablersBM>> CreateEnablers(int Id, EnablersBM enablersBM)
        {

            try
            {
                var addEnablersDTO = EnablersMapper.AddEnablersDTO(enablersBM);

                var result = await _enablerRepository.CreateEnablers(Id, addEnablersDTO);

                return Result.Ok(EnablersMapper.GetEnablerBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<EnablerTypeBM>> SaveEnablerType(int Id, EnablerTypeBM enablers)
        {
            try
            {
                var enablersdto = EnablerTypeMapper.GetEnablersDTOFromEnablersBM(enablers);
                var resultDTO = await _enablerRepository.SaveEnablerType(Id, enablersdto);
                if (resultDTO == null)
                {
                    return null;
                }
                var resultBM = EnablerTypeMapper.GetEnablersBMFromEnablersDTO(resultDTO);
                return Result.Ok(resultBM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<bool>> RemoveEnablerType(int id)
        {
            try
            {
                var result = await _enablerRepository.RemoveEnablerType(id);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Result<bool>> RemoveEnabler(int id)
        {
            try
            {
                var result = await _enablerRepository.RemoveEnabler(id);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
