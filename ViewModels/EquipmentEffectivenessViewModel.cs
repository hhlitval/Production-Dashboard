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
            IEnumerable<EquipmentEffectiveness> equipmentEffectivenesses = LoadDbData.GetEquipmentEffectiveness(new DateTime(2008, 1, 1), new DateTime(2008, 12, 31));
            
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

        private double CalculateOverallEquipmentEffectiveness(IEnumerable<EquipmentEffectiveness> equipmentEffectivenesses)
        {
            Availability = 
                (equipmentEffectivenesses.Select(a => a.OperatingTimeTotal).FirstOrDefault()) /
                (equipmentEffectivenesses.Select(a => a.ScheduledTimeTotal).FirstOrDefault());

            Performance = 
                (equipmentEffectivenesses.Select(a => a.ProductionTotal).FirstOrDefault()) /
                (((equipmentEffectivenesses.Select(a => a.OperatingTimeTotal).FirstOrDefault()))*140);

            Quality = 
                ((equipmentEffectivenesses.Select(a => a.ProductionTotal).FirstOrDefault()) -
                (equipmentEffectivenesses.Select(a => a.ProductDefectTotal).FirstOrDefault())) /
                (equipmentEffectivenesses.Select(a => a.ProductionTotal).FirstOrDefault());

            return (double)(Availability*Performance*Quality)*100;
        }
    }
}
