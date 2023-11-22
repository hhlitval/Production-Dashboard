using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;
using Production_Analysis.Models;
using Production_Analysis.DbServices;
using LiveChartsCore.Drawing;

namespace Production_Analysis.ViewModels
{
    public class ProductionVolumeViewModel : BaseViewModel
    {        
        public ISeries[] ProductionChart{ get; set; }
        public Axis[] XAxis { get; set; }
        public Axis[] YAxis { get; set; }       

        public ProductionVolumeViewModel(TimePeriod period)
        {
            IEnumerable<ProductionKPI> productionOutput = LoadDbData.GetProductionVolume(period);

            ProductionChart = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    DataPadding = new LvcPoint(0, 0.5),
                    Values = productionOutput.Select(o => o.ProductionOutput),
                    Name = null,
                    //Fill = null,
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

            XAxis = new[]
            {
                new Axis
                {
                    Labels = productionOutput.Select(c => (c.MonthYear).ToString("MMM yy")).ToArray(),
                    TextSize = 14
                }
            };

            YAxis = new []
                {
                new Axis
                {
                    Labeler = (value) => value.ToString("0 t"),
                    MinLimit = 0,
                    MaxLimit = 110000,
                    MinStep = 5000,
                    SeparatorsPaint = new SolidColorPaint(new SKColor(230, 230, 247)),
                    TextSize = 14
                }
            };
        } 
    }
}

