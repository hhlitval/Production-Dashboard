using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_Analysis.DbServices;
using Production_Analysis.Models;

namespace Production_Analysis.ViewModels
{
    public class ProductionDowntimeViewModel : BaseViewModel
    {
        public ISeries[] ProductionDowntime { get; set; }
        public Axis[] XAxis { get; set; }
        public Axis[] YAxis { get; set; }

        public ProductionDowntimeViewModel()
        {
            IEnumerable<ProductionKPI> productionDowntime = LoadDbData.GetProductionDowntime(MainViewModel.start, MainViewModel.end);

            ProductionDowntime = new ISeries[]
            {
                new ColumnSeries<decimal>
                {
                    Values = productionDowntime.Select(w => w.Downtime),
                    Name = null,
                    Fill = new SolidColorPaint(new SKColor(90, 169, 230)),
                    // Defines the distance between every bars in the series
                    Padding = 7,
                    DataLabelsSize = 2,

                    // Defines the max width a bar can have
                    MaxBarWidth = double.PositiveInfinity,
                    Rx = 50,
                    Ry = 50
                }
            };

            XAxis = new[]
        {
                new Axis
                {
                    Labels = productionDowntime.Select(c => (c.MonthYear).ToString("MMM yy")).ToArray(),
                    TextSize = 14
                }
            };

            YAxis = new[]
            {
                new Axis
                {
                    SeparatorsPaint = null,
                    Labeler = (value) => value.ToString("0 Std"),                    
                    TextSize = 14
                }
            };
        }        
    }    
}

