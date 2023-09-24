using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace Production_Analysis.ViewModels
{
    public class ProductionChartViewModel : BaseViewModel
    {
        private readonly SKColor productionChartColor = new SKColor(216, 49, 91);
        private readonly SolidColorPaint productivityChartColor = new SolidColorPaint(new SKColor(0, 48, 73)) { StrokeThickness = 3 };
        
        public ISeries[] ProductionAndProductivityChart{ get; set; }
        public Axis[] XAxes { get; set; }

        public ProductionChartViewModel()
        {
             ProductionAndProductivityChart
                = new ISeries[]
                {
                    new ColumnSeries<decimal>
                    {
                        Name = "Produktionsmenge",
                        Values = new decimal[] { 4, 2, 2, 8, 1, 6, 3 },
                        Fill = new SolidColorPaint(productionChartColor)
                    },
                    new LineSeries<decimal>
                    {
                        Name = "Materialproduktivität",
                        Values = new decimal[] { 2, 1, 3, 5, 3, 4, 6 },
                        Stroke = productivityChartColor,
                        Fill = null
                    }
                };
            XAxes = new []
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labels = new string[] { "Anne", "Johnny", "Zac", "Rosa" }
                }
            };
        } 
    }
}

