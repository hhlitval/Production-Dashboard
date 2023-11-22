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
    public class ProductionCostsViewModel : BaseViewModel
    {
        public ISeries[] ProductionCosts { get; set; }
        public Axis[] XAxis { get; set; }
        public Axis[] YAxis { get; set; }

        public ProductionCostsViewModel(TimePeriod period)
        {
            IEnumerable<ProductionKPI> productionCosts = LoadDbData.GetProductionCosts(period);

            ProductionCosts = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    DataPadding = new LvcPoint(0, 0.5),
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
