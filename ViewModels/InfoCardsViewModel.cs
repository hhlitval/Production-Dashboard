using Production_Analysis.DbServices;
using Production_Analysis.Models;
using Production_Analysis.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.ViewModels
{
    public class InfoCardsViewModel : BaseViewModel
    {       
        public decimal ProductionTotal { get; set; }
        public decimal ProductionDefectsPercent { get; set; }
        public decimal EnergyConsumption { get; set; }
        public decimal Emissions { get; set; }

        public InfoCardsViewModel()
        {
            IEnumerable<ProductionKPI> productionIndicators = LoadDbData.GetProductionIndicators(MainViewModel.start, MainViewModel.end);

            ProductionTotal = productionIndicators.Select(p => p.ProductionOutput).Sum();
            ProductionDefectsPercent = (productionIndicators.Select(p => p.ProductionDefect).Sum())/ ProductionTotal;
            EnergyConsumption = (productionIndicators.Select(p => p.EnergyConsumption).Sum())/ ProductionTotal;
            Emissions = (productionIndicators.Select(p => p.Emissions).Sum()) / ProductionTotal;
        }
    }
}
