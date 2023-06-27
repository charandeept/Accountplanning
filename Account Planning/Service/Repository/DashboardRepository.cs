using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.Common.Contants;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AccountPlanningContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public DashboardRepository(AccountPlanningContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<DashboardDTO> DashboardData()
        {
            DashboardDTO users = new DashboardDTO();
            using (var con = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Constants.GetHeatmap, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);

                //table1
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var list = _mapper.Map<EngagementHealth>(row);
                    users.EngagementHealths.Add(list);
                }

                //table 2
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var list = _mapper.Map<FinancialHealth>(row);
                    users.FinancialHealths.Add(list);
                }
                 
                //table 3
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var list = _mapper.Map<Metrics>(row);
                    users.Metric.Add(list);
                }

                //table 4
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    var list = _mapper.Map<NoOfAccounts>(row);
                    users.NoOfAccounts.Add(list);
                }
            }
            return await Task.FromResult(users);
        }

        public async Task<SearchDTO> SearchCustomer(string customername)
        {
            SearchDTO users1 = new SearchDTO();
            using (var con = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Constants.SearchCustomer, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@names", customername);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var list = _mapper.Map<CustomerList>(row);
                    users1.CustomerList.Add(list);
                }
            }
            return await Task.FromResult(users1);
        }

        public async Task<List<AccountDetailsDTO>> GetDetails(int cardId)
        {
            List<AccountDetailsDTO> accountDetailsLists = new List<AccountDetailsDTO>();
            using (var dbConnection = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Constants.GetAccountDetails, (SqlConnection)dbConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Id", cardId);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        var list = _mapper.Map<AccountDetailsDTO>(row);
                        accountDetailsLists.Add(list);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return await Task.FromResult(accountDetailsLists);
            }
        }

        public async Task<List<CustomerDTO>> GetCustomerList(Customer customer)
        {
            List<CustomerDTO> customerLists = new List<CustomerDTO>();
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Constants.GetCustomerList, (SqlConnection)connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@UserId", customer.userId);
                da.SelectCommand.Parameters.AddWithValue("@UserRoleId", customer.userRoleId);
                da.SelectCommand.Parameters.AddWithValue("@UserMail", customer.userEmail);
                da.SelectCommand.Parameters.AddWithValue("@PageNumber", customer.pageNumber);
                da.SelectCommand.Parameters.AddWithValue("@RowsOfPage", customer.rowsOfPage);
                da.SelectCommand.Parameters.AddWithValue("@SortingCol", customer.sortingColumn);
                da.SelectCommand.Parameters.AddWithValue("@SortType", customer.sortType);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        var list = _mapper.Map<CustomerDTO>(row);
                        customerLists.Add(list);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return await Task.FromResult(customerLists);
        }

        public async Task<bool> CreateMetrics(MetricsDTO metrics)
        {
            byte OperationID;
            int NoOfRowsAffected = 0;
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AccountPlanning"));
            SqlCommand command = new SqlCommand(Constants.CreateMetrics, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (metrics.Id == 0)
            {
                OperationID = 1; //Creating Metrics
            }
            else
            {
                OperationID = 2; //Editing Metrics
            }
            command.Parameters.AddRange(new[]
            {
                new SqlParameter("@UserId", metrics.UserID),
                new SqlParameter("@OperatorId", metrics.OperatorID),
                new SqlParameter("@Value", metrics.Value),
                new SqlParameter("@Id", metrics.Id),
                new SqlParameter("@MetricsId", metrics.MetricsID),
                new SqlParameter("@OperationType",OperationID),
            });
            connection.Open();
            try
            {
                NoOfRowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return await Task.FromResult(NoOfRowsAffected == 1 ? true : false);
        }

        public async Task<bool> RemoveMetrics(int id)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AccountPlanning"));
            SqlCommand command = new SqlCommand(Constants.RemoveMetrics, connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter1 = new SqlParameter()
            {
                ParameterName = "@CardId",
                Value = id
            };
            command.Parameters.Add(parameter1);
            connection.Open();
            try
            {
                Result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return await Task.FromResult(Result == 1 ? true : false);
        }
         
        public async Task<FilterDTO> CustomerFilter(List<FilterGridDTO> filters)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("AccountPlanning")))
            {
                cn.Open();
                using (SqlCommand command = new SqlCommand(Constants.Filter, cn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    DataTable datatable = new DataTable();
                    datatable.Columns.Add("UserId", typeof(Int32));
                    datatable.Columns.Add("ColumnName", typeof(string));
                    datatable.Columns.Add("Operator", typeof(string));
                    datatable.Columns.Add("Value", typeof(string));

                    foreach (FilterGridDTO filtergriddto in filters)
                    {
                        datatable.Rows.Add(filtergriddto.UserId, filtergriddto.ColumnName, filtergriddto.Operator, filtergriddto.Value);
                    }
                    FilterDTO users = new FilterDTO();
                    SqlDataAdapter da = new SqlDataAdapter(Constants.Filter, (SqlConnection)cn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@param1", datatable);
                    DataTable datatable1 = new DataTable();
                    da.Fill(datatable1);
                    foreach (DataRow row in datatable1.Rows)
                    {
                        var list = _mapper.Map<Filter>(row);
                        users.Filter.Add(list);
                    }
                    return await Task.FromResult(users);
                }
            }
        }
    }
}


