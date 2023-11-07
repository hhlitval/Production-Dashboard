using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_Analysis.DbServices;
using Production_Analysis.Models;

namespace Production_Analysis.ViewModels
{
    public class ProductionCostsViewModel : BaseViewModel
    {
        public ISeries[] ProductionCosts { get; set; }
        public Axis[] XAxis { get; set; }
        public Axis[] YAxis { get; set; }

        public ProductionCostsViewModel()
        {
            IEnumerable<ProductionKPI> productionCosts = LoadDbData.GetProductionCosts(MainViewModel.start, MainViewModel.end);

            ProductionCosts = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    Values = productionCosts.Select(o => o.ProductionCosts),
                    Name = null,
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)) { StrokeThickness = 3 },
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

            XAxis = new[]
            {
                new Axis
                {
                    Labels = productionCosts.Select(c => (c.MonthYear).ToString("MMM yy")).ToArray(),
                    TextSize = 14
                }
            };

            YAxis = new[]
                {
                new Axis
                {                    
                    SeparatorsPaint = new SolidColorPaint(new SKColor(230, 230, 247)),
                    TextSize = 14
                }
            };
        }
    }
}
