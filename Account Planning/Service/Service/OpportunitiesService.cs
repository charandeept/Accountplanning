using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class OpportunitiesService : IOpportunitiesService
    {
        private readonly IOpportunitiesRepository _opportunitiesRepository;

        public OpportunitiesService(IOpportunitiesRepository opportunitiesRepository)
        {
            _opportunitiesRepository = opportunitiesRepository;

        }
        public async Task<Result<List<OpportunitiesBM>>> GetOpportunities(int CustomerId)
        {
            try
            {

                var result = await _opportunitiesRepository.GetOpportunities(CustomerId);


                if (result == null)
                {
                    return null;
                }

                return Result.Ok(OpportunitiesMapper.GetOpportunitiesBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<CatalogueAwarenessBM>> GetCatalogueAwareness(int CustomerId)
        {
            try
            {
                var result = await _opportunitiesRepository.GetCatalogueAwareness(CustomerId);

                if (result == null)
                {
                    return null;
                }
                return Result.Ok(CatalogueAwarenessMapper.GetCatalogueAwarenessBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Result<RoadMapDetailsBM>> UpdateRoadMapDetails(int CustomerId, RoadMapDetailsBM roadMapDetailsBM)
        {

            try
            {
                var roadMapdetailsDTO = RoadMapDetailsMapper.GetRoadMapDetailsDTO(roadMapDetailsBM);

                var result = await _opportunitiesRepository.UpdateRoadMapDetails(CustomerId, roadMapdetailsDTO);

                /*if (result == null)
                {
                    return null;
                }*/
                return Result.Ok(RoadMapDetailsMapper.GetRoadMapDetailsBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<Result<List<CategoryDetailsBM>>> GetCategoryDetails()
        {
            try
            {
                var result = await _opportunitiesRepository.GetCategoryDetails();


                if (result == null)
                {
                    return null;
                }

                return Result.Ok(CategoryDetailsMapper.GetCategoryDetailsBMs(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public async Task<Result<PainPointsBM>> GetPainPoints(int CustomerId)
        {
            try
            {
                var result = await _opportunitiesRepository.GetPainPointDetails(CustomerId);
                if (result == null)
                {
                    return null;
                }
                return Result.Ok(PainPointsMapper.GetPainPointsBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Result<PainPointsDetailsBM>> UpdatePainPointsDetails(int CustomerId, PainPointsDetailsBM painPointsDetailsBM)
        {

            try
            {
                var painPointsDetailsDTO = PainPointsDetailsMapper.GetPainPointsDetailsDTO(painPointsDetailsBM);

                var result = await _opportunitiesRepository.UpdatePainPointsDetails(CustomerId, painPointsDetailsDTO);

                return Result.Ok(PainPointsDetailsMapper.GetPainPointsDetailsBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<Result<OpportunitiesBM>> UpdateOpportunities(int RoleId, OpportunitiesBM opportunitiesBM)
        {
            try
            {
                var opportunitieDTO = OpportunitiesMapper.GetOpportunitiesDTO(opportunitiesBM);

                var result = await _opportunitiesRepository.UpdateOpportunities(RoleId, opportunitieDTO);

                return Result.Ok(OpportunitiesMapper.GetOpportunitiesBM(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }


}
