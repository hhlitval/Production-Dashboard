using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class ProductionDowntime
    {
        public decimal Downtime { get; set; }
        public DateTime MonthYear { get; set; }
    }
}
