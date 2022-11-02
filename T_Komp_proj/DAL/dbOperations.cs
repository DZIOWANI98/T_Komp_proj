using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Dapper;
using System.Windows;
using T_Komp_proj.Classes;
using System.Linq;
using T_Komp_proj.Helpers;

namespace T_Komp_proj.DAL
{

    public static class dbOperations
    {

        public static bool Test_DB_Connection()
        {
            using(SqlConnection cnDB = DataAccess.Get_DB_Connection())
            {
                try
                {
                    cnDB.Query("Select 1");

                    MessageBox.Show($"Connected To DB succesfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                    return true;
                }
                catch(Exception err)
                {
                    MessageBox.Show($"Failed to connect to database \n {err.Message}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }


        }

        public static List<TableInfo> Get_INT_Column_Names()
        {
            using (SqlConnection cnDB = DataAccess.Get_DB_Connection())
            {
                try
                {
                    var result = cnDB.Query<TableInfo>(@"
                        SELECT 
	                        ROW_NUMBER() OVER(ORDER BY COLUMN_NAME ASC) AS ROW_NUMBER,
	                        COLUMN_NAME,
	                        DATA_TYPE
                        FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE DATA_TYPE = 'INT'
                    ");


                    return result.ToList();
                }
                catch (Exception err)
                {
                    MessageBox.Show($"Failed to fetch the columns \n {err.Message}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }

        }
    }
}
