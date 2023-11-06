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
        public decimal ProductionDefectsTotal { get; set; }
        public decimal EnergyConsumptionTotal { get; set; }
        public decimal EmissionsTotal { get; set; }

        //public bool IsPositiveToday { get; set; }
        //public decimal YesterdayWeight { get; set; }
        //public decimal YesterdayDifference { get; set; }
        //public bool IsPositiveYesterday { get; set; }

        public InfoCardsViewModel()
        {
            //IEnumerable<ProductionKPI> infoCards = LoadDbData.GetKeyProductionIndicators(new DateTime(2008, 1, 1), new DateTime(2008, 12, 31));

            //TodayWeight = (from v in weight where v.Date == _today select v.Weight).FirstOrDefault();
            //YesterdayWeight = (from v in weight where v.Date == _yesterday select v.Weight).FirstOrDefault();
            //dayBeforeYesterdayWeight = (from v in weight where v.Date == _dayBeforeYesterday select v.Weight).FirstOrDefault();
            //IsPositiveToday = (TodayDifference = TodayWeight - YesterdayWeight) >= 0 ? false : true;
            //IsPositiveYesterday = (YesterdayDifference = YesterdayWeight - dayBeforeYesterdayWeight) >= 0 ? false : true;
        }
    }
}
