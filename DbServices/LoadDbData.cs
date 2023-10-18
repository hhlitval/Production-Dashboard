using Production_Analysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.DbServices
{
    public static class LoadDbData 
    {
        public static ObservableCollection<Production> LoadData(DateTime startDate, DateTime endDate)
        {
            var productionOutput = new ObservableCollection<Production>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT PROD_DATA, SUM(FL_STAHL_PFANNE) as OUTPUT
                                            FROM Production 
                                                WHERE PROD_DATA between @FROMDATE and @TODATE
                                                GROUP BY PROD_DATA
                                                ORDER BY PROD_DATA";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionOutput.Add(new Production() { MonthYear = (DateTime)reader["PROD_DATA"], Output = (decimal)reader["OUTPUT"] });
                    }
                    reader.Close();

                    return productionOutput;
                }
            }
        }
    }
}
