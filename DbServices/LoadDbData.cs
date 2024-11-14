﻿using LiveChartsCore.Themes;
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
        public static ObservableCollection<ProductionKPI> GetProductionVolume(TimePeriod period)
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
                    command.CommandText = @"SELECT ProductionVolume, ProdDate  
                                            FROM ProductionOverview
                                            WHERE ProdDate BETWEEN @FROMDATE and @TODATE
                                            ORDER BY ProdDate";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = period.Start;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = period.End;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionOutput.Add(new ProductionKPI()
                        {
                            ProductionOutput = (decimal)reader["ProductionVolume"],
                            MonthYear = (DateTime)reader["ProdDate"]
                        });
                    }
                    reader.Close();

                    return productionOutput;
                }
            }
        }

        public static ObservableCollection<ProductionKPI> GetProductionDowntime(TimePeriod period)
        {
            var productionDowntime = new ObservableCollection<ProductionKPI>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT Ausfallzeit, ProdDate
                                            FROM ProductionOverview
                                            WHERE ProdDate BETWEEN @FROMDATE and @TODATE
                                            ORDER BY ProdDate";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = period.Start;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = period.End;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionDowntime.Add(new ProductionKPI()
                        {
                            Downtime = (decimal)reader["Ausfallzeit"],
                            MonthYear = (DateTime)reader["ProdDate"]
                        });
                    }
                    reader.Close();

                    return productionDowntime;
                }
            }
        }

        public static ObservableCollection<ProductionKPI> GetEquipmentEffectiveness(TimePeriod period)
        {
            var equipmentEffectivenesses = new ObservableCollection<ProductionKPI>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT ProductionVolume, Ausschuss, Laufzeit, Betriebszeit
                                            FROM ProductionOverview
                                            WHERE ProdDate BETWEEN @FROMDATE and @TODATE";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = period.Start;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = period.End;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        equipmentEffectivenesses.Add(new ProductionKPI()
                        {
                            ProductionOutput = (decimal)reader["ProductionVolume"],
                            ProductionDefect = (decimal)reader["Ausschuss"],
                            OperatingTime = (decimal)reader["Laufzeit"],
                            ScheduledTime = (short)reader["Betriebszeit"]
                        });
                    }
                    reader.Close();

                    return equipmentEffectivenesses;
                }
            }
        }

        public static ObservableCollection<ProductionKPI> GetProductionIndicators(TimePeriod period)
        {
            var productionIndicators = new ObservableCollection<ProductionKPI>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT ProductionVolume, Ausschuss, Energieverbrauch, CO_Emissionen
                                            FROM ProductionOverview
                                            WHERE ProdDate BETWEEN @FROMDATE and @TODATE
                                            ORDER BY ProdDate";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = period.Start;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = period.End;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionIndicators.Add(new ProductionKPI()
                        {
                            ProductionOutput = (decimal)reader["ProductionVolume"],
                            ProductionDefect = (decimal)reader["Ausschuss"],
                            EnergyConsumption = (decimal)reader["Energieverbrauch"],
                            Emissions = (decimal)reader["CO_Emissionen"]
                        });
                    }
                    reader.Close();

                    return productionIndicators;
                }
            }
        }

        public static ObservableCollection<ProductionKPI> GetProductionCosts(TimePeriod period)
        {
            var productionCosts = new ObservableCollection<ProductionKPI>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT Produktionskosten, ProdDate
                                            FROM ProductionOverview
                                            WHERE ProdDate BETWEEN @FROMDATE and @TODATE
                                            ORDER BY ProdDate";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = period.Start;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = period.End;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productionCosts.Add(new ProductionKPI()
                        {
                            ProductionCosts = (decimal)reader["Produktionskosten"],
                            MonthYear = (DateTime)reader["ProdDate"]
                        });
                    }
                    reader.Close();

                    return productionCosts;
                }
            }
        }

        public static ObservableCollection<Shipping> GetShipmentData(TimePeriod period)
        {
            var shippings = new ObservableCollection<Shipping>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT country, SUM(shipment_weight) as shipment_weight
                                            FROM Shipping
                                            WHERE shipping_date BETWEEN @FROMDATE and @TODATE
                                            GROUP BY country
                                            ORDER BY shipment_weight DESC";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = period.Start;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = period.End;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        shippings.Add(new Shipping()
                        {
                            DestinationLand = (string)reader["country"],
                            Quantity = (int)reader["shipment_weight"]
                        });
                    }
                    reader.Close();

                    return shippings;
                }
            }
        }

        public static ObservableCollection<string> GetYearsData()
        {
            var years = new ObservableCollection<string>();

            using (var connection = new DbConnection().GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT YEAR(ProdDate) AS Year
                                            FROM ProductionOverview
                                            GROUP BY YEAR(ProdDate)";
                    
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        years.Add(((int)reader["Year"]).ToString());
                    }
                    reader.Close();

                    return years;
                }
            }
        }
    }
}