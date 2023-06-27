using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.Common.Contants;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly AccountPlanningContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserDetailsRepository(AccountPlanningContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUser(string emailId)
        {
            List<UserDTO> getUser = new List<UserDTO>();

            using (var con = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Constants.GetUser, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@emailId", emailId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var user = _mapper.Map<UserDTO>(row);
                    getUser.Add(user);
                }
            }
            return await Task.FromResult(getUser);
        }
    }
}
