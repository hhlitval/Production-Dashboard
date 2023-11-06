using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Production_Analysis.Models;
using Production_Analysis.DbServices;
using System.Windows.Media.Media3D;

namespace Production_Analysis.ViewModels
{
    public class ProductionVolumeViewModel : BaseViewModel
    {        
        public ISeries[] ProductionChart{ get; set; }
        public Axis[] XAxis { get; set; }
        public Axis[] YAxis { get; set; }

        public ProductionVolumeViewModel()
        {
            IEnumerable<ProductionKPI> output = LoadDbData.GetProductionVolume(new DateTime(2008, 1, 1), new DateTime(2008, 12, 31));

            ProductionChart = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    Values = output.Select(o => o.ProductionOutput),
                    Name = "Produktion",
                    Fill = null,
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

            XAxis = new[]
            {
                new Axis
                {
                    Labels = output.Select(c => (c.MonthYear).ToString("MMM yy")).ToArray(),
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

