using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface IDashboardRepository
    {
        public Task<DashboardDTO> DashboardData();
        public Task<SearchDTO> SearchCustomer(string customername);
        public Task<List<AccountDetailsDTO>> GetDetails(int cardId);
        public Task<List<CustomerDTO>> GetCustomerList(Customer customer);
        public Task<bool> CreateMetrics(MetricsDTO metrics);
        public Task<bool> RemoveMetrics(int id);
        public Task<FilterDTO> CustomerFilter(List<FilterGridDTO> filters);
    }
}


