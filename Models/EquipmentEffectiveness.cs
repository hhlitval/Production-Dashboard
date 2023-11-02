using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class EquipmentEffectiveness
    {
        public decimal ProductionTotal { get; set; }
        public decimal ProductDefectTotal { get; set; }
        public decimal OperatingTimeTotal { get; set; }
        public int ScheduledTimeTotal { get; set; }
        public decimal DowntimeTotal { get; set; }

    }
}
