using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IService
{
    public interface IDashboardService
    {
        public Task<Result<DashboardDTO>> DashboardData();
        public Task<Result<SearchDTO>> SearchCustomer(string customername);
        public Task<Result<List<AccountDetailsDTO>>> GetDetails(int cardId);
        public Task<Result<List<CustomerDTO>>> GetCustomerList(Customer customer);
        public Task<Result<bool>> CreateMetrics(MetricsDTO metrics);
        public Task<Result<bool>> RemoveMetrics(int id);
        public Task<Result<FilterDTO>> CustomerFilter(List<FilterGridDTO> filters);
    }
}

