using System;

namespace Production_Analysis.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public readonly static DateTime start = new DateTime(2017, 1, 1);
        public readonly static DateTime end = new DateTime(2017, 12, 31);
        public ProductionVolumeViewModel ProductionVolumeViewModel { get; }
        public ProductionDowntimeViewModel ProductionDowntimeViewModel { get; }        
        public EquipmentEffectivenessViewModel EquipmentEffectivenessViewModel { get; }
        public InfoCardsViewModel InfoCardsViewModel { get; }
        public ShippingMapViewModel ShippingMapViewModel { get; }
        public ProductionCostsViewModel ProductionCostsViewModel { get; }

        public MainViewModel()
        {
            ProductionVolumeViewModel = new ProductionVolumeViewModel();
            ProductionDowntimeViewModel = new ProductionDowntimeViewModel();
            #pragma warning disable CS0612 // Type or member is obsolete
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel();
            #pragma warning restore CS0612 // Type or member is obsolete
            InfoCardsViewModel = new InfoCardsViewModel();
            ShippingMapViewModel = new ShippingMapViewModel();
            ProductionCostsViewModel = new ProductionCostsViewModel();
        }

    }
}
