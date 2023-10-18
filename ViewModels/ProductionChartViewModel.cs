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
    public class ProductionChartViewModel : BaseViewModel
    {        
        public ISeries[] ProductionAndProductivityChart{ get; set; }
        public string[]? Date { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis YAxes { get; set; }

        public ProductionChartViewModel(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Production> output = LoadDbData.LoadData(startDate, endDate);

            ProductionAndProductivityChart = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    Values = output.Select(w => w.Output),
                    Fill = null,
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };
            
            XAxes = new[]
            {
                new Axis
                {
                    Labels = output.Select(c => (c.MonthYear).ToString("dd.MM.yy")).ToArray()
                }
            };

            YAxes = new Axis
                {
                    SeparatorsPaint = null
                };
        } 
    }
}

