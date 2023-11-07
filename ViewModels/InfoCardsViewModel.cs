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
            IEnumerable<ProductionKPI> infoCards = LoadDbData.GetProductionVolume(new DateTime(2008, 1, 1), new DateTime(2008, 12, 31));

            ProductionTotal = infoCards.Select(p => p.ProductionOutput).Sum();
            ProductionDefectsPercent = (infoCards.Select(p => p.ProductionDefect).Sum())/ ProductionTotal;
            EnergyConsumption = (infoCards.Select(p => p.EnergyConsumption).Sum())/ ProductionTotal;
            Emissions = (infoCards.Select(p => p.Emissions).Sum()) / ProductionTotal;
        }
    }
}
