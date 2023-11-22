using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;
using Production_Analysis.DbServices;
using Production_Analysis.Models;
using LiveChartsCore.Drawing;

namespace Production_Analysis.ViewModels
{
    public class ProductionDowntimeViewModel : BaseViewModel
    {
        public ISeries[] ProductionDowntime { get; set; }
        public Axis[] XAxis { get; set; }
        public Axis[] YAxis { get; set; }

        public ProductionDowntimeViewModel(TimePeriod period)
        {
            IEnumerable<ProductionKPI> productionDowntime = LoadDbData.GetProductionDowntime(period);

            ProductionDowntime = new ISeries[]
            {
                new ColumnSeries<decimal>
                {
                    DataPadding = new LvcPoint(0, 0.5),
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

