using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<Result<DashboardDTO>> DashboardData()
        {
            try
            {
                var result = await _dashboardRepository.DashboardData();
                return Result.Ok(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<SearchDTO>> SearchCustomer(string customername)
        {
            try
            {
                var result = await _dashboardRepository.SearchCustomer(customername);
                return Result.Ok(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<List<AccountDetailsDTO>>> GetDetails(int cardId)
        {

            var result = await _dashboardRepository.GetDetails(cardId);
            return Result.Ok(result);
        }

        public async Task<Result<List<CustomerDTO>>> GetCustomerList(Customer customer)
        {
            var result = await _dashboardRepository.GetCustomerList(customer);
            return Result.Ok(result);
        }

        public async Task<Result<bool>> CreateMetrics(MetricsDTO metrics)
        {
            try
            {
                var result = await _dashboardRepository.CreateMetrics(metrics);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<bool>> RemoveMetrics(int id)
        {
            try
            {
                var result = await _dashboardRepository.RemoveMetrics(id);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<FilterDTO>> CustomerFilter(List<FilterGridDTO> filters)
        {
            try
            {
                var result = await _dashboardRepository.CustomerFilter(filters);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


