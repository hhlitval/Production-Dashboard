using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class Production
    {
        public decimal Output { get; set; }
        public DateTime MonthYear { get; set; }
        public decimal Productivity { get; set; }
    }
}
