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
        public string[]? Date { get; set; }
        public Axis[] XProductionChart { get; set; }
        public Axis YProductionChart { get; set; }

        public ProductionVolumeViewModel()
        {
            //IEnumerable<Production> output = LoadDbData.LoadData(startDate, endDate);

            ProductionChart = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    Values = new decimal[]{166,180,123,158,90,124,146,162,150,169,166,144},
                    //Values = output.Select(w => w.Output),
                    Fill = null,
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

            XProductionChart = new[]
            {
                new Axis
                {
                    Labels = new string[]{"Jan 22", "Feb 22", "Mär 22", "Apr 22", "Mai 22", "Jun 22", "Jul 22",
                    "Aug 22", "Sep 22", "Okt 22", "Nov 22", "Dez 22"}
                    //Labels = output.Select(c => (c.MonthYear).ToString("dd.MM.yy")).ToArray()
                }
            };

            YProductionChart = new Axis
                {
                    SeparatorsPaint = null
                };
        } 
    }
}

