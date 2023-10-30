using Production_Analysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.DbServices
{
    public static class LoadDbData 
    {
        public static ObservableCollection<Production> ProductionVolume(DateTime startDate, DateTime endDate)
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
                    command.CommandText = @"SELECT FORMAT(PROD_DATA, 'MMM yyyy') AS month_year, 
                                            CAST(ROUND(SUM(FL_STAHL_PFANNE),1)AS DECIMAL(6,1)) AS ProductionVolume
                                            FROM Production
                                            WHERE PROD_DATA between @FROMDATE and @TODATE
                                            GROUP BY FORMAT(PROD_DATA, 'MMM yyyy')
                                            ORDER BY MIN(PROD_DATA)";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionOutput.Add(new Production()
                        {
                            MonthYear = DateTime.ParseExact((string)reader["month_year"], "MMM yyyy", CultureInfo.InvariantCulture),
                            Output = (decimal)reader["ProductionVolume"]
                        });
                    }
                    reader.Close();

                    return productionOutput;
                }
            }
        }
    }
}
