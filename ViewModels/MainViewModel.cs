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

        public MainViewModel(DateTime start, DateTime end)
        {
            ProductionInfoCardsViewModel = new ProductionInfoCardsViewModel();
            ProductionChartViewModel = new ProductionChartViewModel(start, end);
            PieChartViewModel = new PieChartViewModel();
            EnergyEmissionsViewModel = new EnergyEmissionsViewModel();
            ShippingMapViewModel = new ShippingMapViewModel();
        }

    }
}
