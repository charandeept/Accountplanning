using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.Common.Contants;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Com.ACSCorp.AccountPlanning.Service.Repository.Mapper;
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

    public class EnablerRepository : IEnablerRepository
    {
        private readonly AccountPlanningContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public EnablerRepository(AccountPlanningContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<EnablerDTO> GetEnablers()
        {
            EnablerDTO enablers = new EnablerDTO();
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Constants.GetEnablerdetails, (SqlConnection)connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dt = new DataSet();
                da.Fill(dt);
                foreach (DataRow row in dt.Tables[0].Rows)
                {
                    try
                    {
                        var list = _mapper.Map<Enabler>(row);
                        enablers.Enablers.Add(list);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                foreach (DataRow row in dt.Tables[1].Rows)
                {
                    try
                    {
                        var list = _mapper.Map<CountOfEnabler>(row);
                        enablers.Count.Add(list);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return await Task.FromResult(enablers);
            }
        }

        public async Task<AddEnablersDTO> CreateEnablers(int Id, AddEnablersDTO addEnablersDTO)
        {
            var enablersTable = EnablersModelMapper.GetEnablersDetails(addEnablersDTO);                //AddEnablersDTO(addEnablersDTO);

            var enablers = await _dbContext.Enablers.FirstOrDefaultAsync(x => x.Id == Id);

            if (enablers != null)
            {
                enablers.CustomerId = enablersTable.CustomerId;
                enablers.AuthorName = enablersTable.AuthorName;
                enablers.EnablerTypeId = enablersTable.EnablerTypeId;
                enablers.Title = enablersTable.Title;
                enablers.Link = enablersTable.Link;

                _dbContext.Enablers.Update(enablers);
                await _dbContext.SaveChangesAsync();
                return EnablersModelMapper.GetEnablersDTO(await _dbContext.Enablers.FirstOrDefaultAsync(x => x.Id == Id));
            }
            else
            {
                await _dbContext.Enablers.AddAsync(enablersTable);
                await _dbContext.SaveChangesAsync();
                return EnablersModelMapper.GetEnablersDTO(enablersTable);
            }
        }

        public async Task<EnablerTypeDTO> SaveEnablerType(int Id, EnablerTypeDTO enablers)
        {
            var enablerDetails = await _dbContext.EnablerType.FirstOrDefaultAsync(x => x.Id == Id);
            var EnablerType = EnablerTypeMapper.GetEnablerTypeTable(enablers);
            if (enablerDetails != null)
            {
                enablerDetails.Title = enablers.Title;
                await _dbContext.SaveChangesAsync();
                return EnablerTypeMapper.GetEnablersDTOFromEnablerTypeTable(await _dbContext.EnablerType.FirstOrDefaultAsync(x => x.Id == Id));
            }
            else
            {
                await _dbContext.AddAsync(EnablerType);
                await _dbContext.SaveChangesAsync();
                var x = await _dbContext.EnablerType.MaxAsync(y => y.Id);
                return EnablerTypeMapper.GetEnablersDTOFromEnablerTypeTable(await _dbContext.EnablerType.FirstOrDefaultAsync(cbi => cbi.Id == x));
            }
        }
        public async Task<bool> RemoveEnablerType(int id)
        {
            var enablerDetails = await _dbContext.EnablerType.FirstOrDefaultAsync(x => x.Id == id);
            if (enablerDetails == null)
            {
                return false;
            }
            else
            {
                _dbContext.EnablerType.Remove(enablerDetails);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> RemoveEnabler(int id)
        {
            var enablerCardCDetails = await _dbContext.Enablers.FirstOrDefaultAsync(x => x.Id == id);
            if (enablerCardCDetails == null)
            {
                return false;
            }
            else
            {
                _dbContext.Enablers.Remove(enablerCardCDetails);
                await _dbContext.SaveChangesAsync();
                return true;
            }

        }
    }
}
