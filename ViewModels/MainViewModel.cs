using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
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
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel();
            InfoCardsViewModel = new InfoCardsViewModel();
            ShippingMapViewModel = new ShippingMapViewModel();
            ProductionCostsViewModel = new ProductionCostsViewModel();
        }

    }
}
