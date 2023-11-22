using Production_Analysis.Comands;
using Production_Analysis.Models;
using System;
using System.Windows;

namespace Production_Analysis.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public TimePeriod TimePeriod { get; set; } 
            = new TimePeriod() { Start = new DateTime(2017, 1, 1), End = new DateTime(2017, 12, 31) };
        public ProductionVolumeViewModel ProductionVolumeViewModel { get; }
        public ProductionDowntimeViewModel ProductionDowntimeViewModel { get; }        
        public EquipmentEffectivenessViewModel EquipmentEffectivenessViewModel { get; }
        public InfoCardsViewModel InfoCardsViewModel { get; }
        public ShippingMapViewModel ShippingMapViewModel { get; }
        public ProductionCostsViewModel ProductionCostsViewModel { get; }

        [Obsolete]
        public MainViewModel()
        {
            ProductionVolumeViewModel = new ProductionVolumeViewModel(TimePeriod);
            ProductionDowntimeViewModel = new ProductionDowntimeViewModel(TimePeriod);           
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel(TimePeriod);            
            InfoCardsViewModel = new InfoCardsViewModel(TimePeriod);
            ShippingMapViewModel = new ShippingMapViewModel(TimePeriod);
            ProductionCostsViewModel = new ProductionCostsViewModel(TimePeriod);   
        }        
    }
}
