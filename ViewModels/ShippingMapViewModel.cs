using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using Production_Analysis.DbServices;
using Production_Analysis.Models;
using SkiaSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Production_Analysis.ViewModels
{
    public class ShippingMapViewModel : BaseViewModel
    {
        public HeatLandSeries[] GeoSeries { get; set; }
        public List<Shipping>? ShippingVolumesDistribution { get; set; }
        public double ShipmentsTotal { get; set; }
        public ShippingMapViewModel(TimePeriod period)
        {
            IEnumerable<Shipping> shippings = LoadDbData.GetShipmentData(period.Start, period.End);  
            ShipmentsTotal = shippings.Select(p => p.Quantity).Sum();

            GeoSeries = new HeatLandSeries[] { new HeatLandSeries {
                    HeatMap = new[]
                        {
                            new SKColor(191, 220, 242).AsLvcColor(), // the first element is the "coldest" 
                            new SKColor(90, 169, 230).AsLvcColor(),
                            new SKColor(4, 105, 181).AsLvcColor() // the last element is the "hottest" 
                        },                   

                    Lands = shippings.Select(item => new HeatLand
                    {
                        Name = GetJsonShortName(item.DestinationLand),
                        Value = item.Quantity
                    }).ToArray()           

                    }
                };
            ShippingVolumesDistribution = shippings.Select(item => new Shipping
            {
                DestinationLand = item.DestinationLand,
                Quantity = item.Quantity,
                Percentage = (item.Quantity/ShipmentsTotal)*100
            }).ToList();
        }

        private string GetJsonShortName(string? landName)
        {            
            using FileStream json = File.OpenRead(@"C:\Users\sasha\source\repos\C#\foo\word-map-index.json");
            List<LandJson>? lands = JsonSerializer.Deserialize<List<LandJson>>(json);
            
            return (from result in lands
                    where result.Name == landName
                    select result.ShortName).FirstOrDefault() ?? "";
        }
    }
}