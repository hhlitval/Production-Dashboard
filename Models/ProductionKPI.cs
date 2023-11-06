using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class ProductionKPI
    {
        public decimal ProductionOutput { get; set; }        
        public decimal ProductionDefect { get; set; }
        public decimal Downtime { get; set; }        
        public decimal OperatingTime { get; set; }
        public int ScheduledTime { get; set; }
        public DateTime MonthYear { get; set; }
    }
}
