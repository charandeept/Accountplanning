using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AccountPlanningTest.MockData
{
    public class ImportExportDMMockData
        {
           public static DataTable DMTemplateData_NotBeNull()
            {
                DataTable dataTable = new DataTable("DMList");
                dataTable.Columns.AddRange(new DataColumn[6] { 
                                        new DataColumn("Innova ID"),
                                        new DataColumn("User Name"),
                                        new DataColumn("User Email"),
                                        new DataColumn("Designation"),
                                        new DataColumn("Role"),
                                        new DataColumn("IsActive")
                                         });
                DataRow dataRow = dataTable.NewRow();

                dataRow[0] = "Innova ID";
                dataRow[1] = "User Name";
                dataRow[2] = "User Email";
                dataRow[3] = "Designation";
                dataRow[4] = "Role";
                dataRow[5] = "IsActive";
                dataTable.Rows.Add(dataRow);
                return dataTable;
            }
        public static DataTable DMTemplate_NullData()
        {
            DataTable dataTable = new DataTable("DMList");
            DataRow dataRow = dataTable.NewRow();      
            dataTable.Rows.Add(dataRow);
            return dataTable;
        }

        public static List<UsersTableDTO> GetUsers()
        {
            return new List<UsersTableDTO>()
            {
                new UsersTableDTO()
                {
                    InnovaId=104539,
                    UserName="Sameera",
                    UserEmail="sameera@innovasolutions.com",
                    Designation="Principal Engineer",
                    IsActiveUI="Y",
                    ModifiedByUI= "",
                    ModifiedDateUI= "14 February, 2023  18:15:03",
                }
            };
        }
    }
}
