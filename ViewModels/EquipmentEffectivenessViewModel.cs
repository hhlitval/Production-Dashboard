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
using System.Net.NetworkInformation;

namespace Production_Analysis.ViewModels
{
    public class EquipmentEffectivenessViewModel : BaseViewModel
    {
        public IEnumerable<ISeries> EquipmentEffectiveness { get; set; }
        public decimal Availability { get; set; }
        public decimal Performance { get; set; }
        public decimal Quality { get; set; }

        [Obsolete]
        public EquipmentEffectivenessViewModel()
        {
            IEnumerable<ProductionKPI> equipmentEffectivenesses = LoadDbData.GetEquipmentEffectiveness(MainViewModel.start, MainViewModel.end);
            
            EquipmentEffectiveness = new GaugeBuilder()
                .WithLabelsSize(30)
                .WithInnerRadius(80)
                .WithLabelFormatter(point => point.PrimaryValue.ToString("F1") + point.Context.Series.Name)
                .WithBackgroundInnerRadius(0)
                .WithBackgroundOffsetRadius(10)
                .WithBackground(new SolidColorPaint(new SKColor(247, 247, 255)))
                .AddValue(CalculateOverallEquipmentEffectiveness(equipmentEffectivenesses), " %", new SKColor(90, 169, 230))
                .BuildSeries();
        }

        private double CalculateOverallEquipmentEffectiveness(IEnumerable<ProductionKPI> equipmentEffectivenesses)
        {
            Availability = 
                (equipmentEffectivenesses.Select(a => a.OperatingTime).Sum()) /
                (equipmentEffectivenesses.Select(a => a.ScheduledTime).Sum());

            Performance = 
                (equipmentEffectivenesses.Select(a => a.ProductionOutput).Sum()) /
                (((equipmentEffectivenesses.Select(a => a.OperatingTime).Sum()))*140);

            Quality = 
                ((equipmentEffectivenesses.Select(a => a.ProductionOutput).Sum()) -
                (equipmentEffectivenesses.Select(a => a.ProductionDefect).Sum())) /
                (equipmentEffectivenesses.Select(a => a.ProductionOutput).Sum());

            return (double)(Availability*Performance*Quality)*100;
        }
    }
}
