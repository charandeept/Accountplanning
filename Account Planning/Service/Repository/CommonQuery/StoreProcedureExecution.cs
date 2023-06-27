using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.CommonQuery
{
    public class StoreProcedureExecution
    {
               
        public async static Task<DataTable> ExecuteStoreProcedure( string SPName, string connectionString, List<SqlParameter> parameters = null)
        {
            DataTable dataTable = new DataTable();            
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SPName, connection);
                if(parameters != null)
                {
                    foreach (SqlParameter sqlParameter in parameters)
                    {
                        command.Parameters.Add(sqlParameter);   
                    }
                }
                               
                SqlDataAdapter adapter = new SqlDataAdapter();
                command.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = command;
                await Task.Run(() => adapter.Fill(dataTable));
            }
            
            return dataTable;
        }
    }
}
