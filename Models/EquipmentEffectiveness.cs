using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class EquipmentEffectiveness
    {
        public Production? Volume { get; set; }
        public DateTime MonthYear { get; set; }
        public decimal ProductDefect { get; set; }
        public decimal OperatingTime { get; set; }
        public ProductionDowntime? Downtime { get; set; }

    }
}
