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
    public class EquipmentEffectivenessViewModel : BaseViewModel
    {
        public IEnumerable<ISeries> EquipmentEfficiency { get; set; } = new GaugeBuilder()
                .WithLabelsSize(30)
                .WithInnerRadius(80)
                .WithLabelFormatter(point => point.PrimaryValue + " %" + point.Context.Series.Name)
                .WithBackgroundInnerRadius(0)
                .WithBackgroundOffsetRadius(10)
                .WithBackground(new SolidColorPaint(new SKColor(247, 247, 255)))
                .AddValue(67.29, "", new SKColor(90, 169, 230))
                .BuildSeries();
    }
}
