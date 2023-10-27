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

namespace Production_Analysis.ViewModels
{
    public class ProductionDowntimeViewModel : BaseViewModel
    {
        
            public ISeries[] ProductionDowntime { get; set; } =
            {
                new ColumnSeries<double>
                {
                    Values = new ObservableCollection<double> { 20, 50, 40, 20, 40, 30, 50, 20, 50, 40, 30, 10 },
                    Fill = new SolidColorPaint(new SKColor(90, 169, 230)),
                    // Defines the distance between every bars in the series
                    Padding = 8,
                    DataLabelsSize = 2,

                    // Defines the max width a bar can have
                    MaxBarWidth = double.PositiveInfinity,
                    Rx = 50,
                    Ry = 50
                }
            };

        public Axis[] XProductionDowntime { get; set; } = new[]
        {
                new Axis
                {
                    Labels = new string[]{"Jan 22", "Feb 22", "Mär 22", "Apr 22", "Mai 22", "Jun 22", "Jul 22",
                    "Aug 22", "Sep 22", "Okt 22", "Nov 22", "Dez 22"}
                }
            };

        public Axis[] YProductionDowntime { get; set; } =
        {
                new Axis
                {
                    SeparatorsPaint = null
                }
            };
    }
    
}

