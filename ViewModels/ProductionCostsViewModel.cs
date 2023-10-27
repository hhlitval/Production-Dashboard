using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.ViewModels
{
    public class ProductionCostsViewModel : BaseViewModel
    {
        public ISeries[] ProductionCosts { get; set; } =
           {
                new LineSeries<double>
                {
                    Values = new double[] { 1, 2, 1, 1.5, 1.2, 0.9, 1, 1.3, 1.5, 1, 1.4, 1.6 },
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

        public Axis[] YProductionCosts { get; set; } =
        {
                new Axis
                {
                    SeparatorsPaint = null
                }
            };

        public Axis[] XProductionCosts { get; set; } = new[]
        {
                new Axis
                {
                    Labels = new string[]{"Jan 22", "Feb 22", "Mär 22", "Apr 22", "Mai 22", "Jun 22", "Jul 22",
                    "Aug 22", "Sep 22", "Okt 22", "Nov 22", "Dez 22"}
                }
            };
    }
}
