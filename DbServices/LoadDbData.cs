using LiveChartsCore.Themes;
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
    public static class LoadDbData 
    {
        public static ObservableCollection<ProductionKPI> GetProductionVolume(DateTime startDate, DateTime endDate)
        {
            var productionOutput = new ObservableCollection<ProductionKPI>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT *
                                            FROM ProductionOverview
                                            WHERE ProdDate between @FROMDATE and @TODATE
                                            ORDER BY ProdDate";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionOutput.Add(new ProductionKPI()
                        {
                            ProductionOutput = (decimal)reader["ProductionVolume"],
                            ProductionDefect = (decimal)reader["Ausschuss"],
                            Downtime = (decimal)reader["Ausfallzeit"],
                            OperatingTime = (decimal)reader["Laufzeit"],
                            ScheduledTime = (short)reader["Betriebszeit"],
                            MonthYear = (DateTime)reader["ProdDate"]
                        });
                    }
                    reader.Close();

                    return productionOutput;
                }
            }
        }

        //public static ObservableCollection<ProductionDowntime> GetProductionDowntime(DateTime startDate, DateTime endDate)
        //{
        //    var productionDowntime = new ObservableCollection<ProductionDowntime>();

        //    using (var connection = new DbConnection().GetConnection())
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand())
        //        {
        //            SqlDataReader reader;
        //            command.Connection = connection;

        //            command.CommandText = @"SELECT ProdDate, Ausfallzeit
        //                                    FROM ProductionOverview
        //                                    WHERE ProdDate between @FROMDATE and @TODATE
        //                                    ORDER BY ProdDate";

        //            command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
        //            command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
        //            reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                productionDowntime.Add(new ProductionDowntime()
        //                {
        //                    MonthYear = (DateTime)reader["ProdDate"],
        //                    Downtime = (decimal)reader["Ausfallzeit"]
        //                });
        //            }
        //            reader.Close();

        //            return productionDowntime;
        //        }
        //    }
        //}

        //public static ObservableCollection<EquipmentEffectiveness> GetEquipmentEffectiveness(DateTime startDate, DateTime endDate)
        //{
        //    var equipmentEffectiveness = new ObservableCollection<EquipmentEffectiveness>();

        //    using (var connection = new DbConnection().GetConnection())
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand())
        //        {
        //            SqlDataReader reader;
        //            command.Connection = connection;

        //            command.CommandText = @"SELECT 
        //                                    SUM(ProductionVolume) as ProductionVolume, 
		      //                              SUM(Ausfallzeit) as Ausfallzeit, 
		      //                              SUM(Ausschuss) as Ausschuss, 
		      //                              SUM(Laufzeit) as Laufzeit, 
        //                                    SUM(Betriebszeit) as Betriebszeit, 
		      //                              YEAR(ProdDate) as ProductionYear
        //                                    FROM ProductionOverview
        //                                    WHERE ProdDate between @FROMDATE and @TODATE
        //                                    GROUP BY YEAR(ProdDate)";

        //            command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
        //            command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
        //            reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                equipmentEffectiveness.Add(new EquipmentEffectiveness()
        //                {
        //                    ProductionTotal = (decimal)reader["ProductionVolume"],
        //                    ProductDefectTotal = (decimal)reader["Ausschuss"],
        //                    OperatingTimeTotal = (decimal)reader["Laufzeit"],
        //                    ScheduledTimeTotal = (int)reader["Betriebszeit"],
        //                    DowntimeTotal = (decimal)reader["Ausfallzeit"]
        //                });
        //            }
        //            reader.Close();

        //            return equipmentEffectiveness;
        //        }
        //    }
        //}

        //public static ObservableCollection<ProductionKPI> GetKeyProductionIndicators(DateTime startDate, DateTime endDate)
        //{
        //    return null;
        //}
    }
}
