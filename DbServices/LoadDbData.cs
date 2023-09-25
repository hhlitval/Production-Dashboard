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
    public class LoadDbData : DbConnection
    {
        public ObservableCollection<Production> WeightStatistics { get; set; }

        public LoadDbData(DateTime start, DateTime end)
        {
            WeightStatistics = LoadData(start, end);
        }

        private ObservableCollection<Production> LoadData(DateTime startDate, DateTime endDate)
        {
            var dbWeightList = new ObservableCollection<Production>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT Date, Weight
                                            FROM TotalWeight 
                                                WHERE Date between @FROMDATE and @TODATE 
                                                ORDER BY Date";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //dbWeightList.Add(new Production() { Date = (DateTime)reader["Date"], Weight = (decimal)reader["Weight"] });
                    }
                    reader.Close();

                    return dbWeightList;
                }
            }
        }
    }
}
