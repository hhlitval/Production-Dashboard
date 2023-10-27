using LiveChartsCore;
using LiveChartsCore.Geo;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using Production_Analysis.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.ViewModels
{
    public class ShippingMapViewModel : BaseViewModel
    {
        public HeatLandSeries[] GeoSeries { get; set; }
        public List<Shipping>? Lands { get; set; }
        public ShippingMapViewModel()
        {
            var lands = new HeatLand[]
            {
                new() { Name = "bra", Value = 14 },
                new() { Name = "mex", Value = 10 },
                new() { Name = "usa", Value = 20 },
                new() { Name = "ind", Value = 12 },
                new() { Name = "deu", Value = 13 },
                new() { Name= "jpn", Value = 15 },
                new() { Name = "chn", Value = 18 },
                new() { Name = "nor", Value = 11 },
                new() { Name = "fra", Value = 8 },
                new() { Name = "esp", Value = 7 },
                new() { Name = "kor", Value = 10 },
                new() { Name = "zaf", Value = 12 },
                new() { Name = "tur", Value = 5 },
                new() { Name = "are", Value = 13 }
            };
            GeoSeries = new HeatLandSeries[] { new HeatLandSeries {
                    HeatMap = new[]
                        {
                            new SKColor(191, 220, 242).AsLvcColor(), // the first element is the "coldest" 
                            new SKColor(90, 169, 230).AsLvcColor(),
                            new SKColor(4, 105, 181).AsLvcColor() // the last element is the "hottest" 
                        },
                    Lands = lands }
                };
            Lands = new List<Shipping>()
            {
                new Shipping { DestinationLand = "USA", Quantity = 12864, Percentage = 14.3M},
                new Shipping { DestinationLand = "China", Quantity = 10136, Percentage = 11.3M},
                new Shipping { DestinationLand = "Japan", Quantity = 7561, Percentage = 8.4M},
                new Shipping { DestinationLand = "Brasilien", Quantity = 7089, Percentage = 7.9M},
                new Shipping { DestinationLand = "Deutschland", Quantity = 6954, Percentage = 7.7M},
                new Shipping { DestinationLand = "Indien", Quantity = 6233, Percentage = 6.9M}
            };
        }
    }
}