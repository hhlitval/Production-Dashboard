using Production_Analysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Production_Analysis.DbServices
{
    public class LoadDbData 
    {
        public static ObservableCollection<Production> GetProductionVolume(DateTime startDate, DateTime endDate)
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

        public static ObservableCollection<ProductionDowntime> GetProductionDowntime(DateTime startDate, DateTime endDate)
        {
            var productionDowntime = new ObservableCollection<ProductionDowntime>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    command.CommandText = @"SELECT ProdDate, Ausfallzeit
                                            FROM ProductionOverview
                                            WHERE ProdDate between @FROMDATE and @TODATE
                                            ORDER BY ProdDate";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionDowntime.Add(new ProductionDowntime()
                        {
                            MonthYear = (DateTime)reader["ProdDate"],
                            Downtime = (decimal)reader["Ausfallzeit"]
                        });
                    }
                    reader.Close();

                    return productionDowntime;
                }
            }
        }

        public static ObservableCollection<EquipmentEffectiveness> GetEquipmentEffectiveness(DateTime startDate, DateTime endDate)
        {
            var equipmentEffectiveness = new ObservableCollection<EquipmentEffectiveness>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    command.CommandText = @"SELECT *
                                            FROM ProductionOverview
                                            WHERE ProdDate between @FROMDATE and @TODATE
                                            ORDER BY ProdDate";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        equipmentEffectiveness.Add(new EquipmentEffectiveness()
                        {
                            Volume = (Production)reader["ProductionVolume"],
                            MonthYear = (DateTime)reader["ProdDate"],
                            ProductDefect = (decimal)reader["Ausschuss"],
                            OperatingTime = (decimal)reader["Laufzeit"],
                            Downtime = (ProductionDowntime)reader["Ausfallzeit"]
                        });
                    }
                    reader.Close();

                    return equipmentEffectiveness;
                }
            }
        }
    }
}
