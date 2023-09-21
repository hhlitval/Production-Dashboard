using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ProductionInfoCardsViewModel ProductionInfoCardsViewModel { get; }
        public ProductionChartViewModel ProductionChartViewModel { get; }
        public PieChartViewModel PieChartViewModel { get; }
        public EnergyEmissionsViewModel EnergyEmissionsViewModel { get; }
        public ShippingMapViewModel ShippingMapViewModel { get; }

        public MainViewModel(ProductionInfoCardsViewModel productionInfoCardsViewModel, ProductionChartViewModel productionChartViewModel, 
            PieChartViewModel pieChartViewModel, EnergyEmissionsViewModel energyEmissionsViewModel, ShippingMapViewModel shippingMapViewModel)
        {
            ProductionInfoCardsViewModel = productionInfoCardsViewModel;
            ProductionChartViewModel = productionChartViewModel;
            PieChartViewModel = pieChartViewModel;
            EnergyEmissionsViewModel = energyEmissionsViewModel;
            ShippingMapViewModel = shippingMapViewModel;
        }

    }
}
