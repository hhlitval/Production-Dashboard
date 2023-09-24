using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class ProductDefect
    {
        public decimal Percentage { get; set; }
        public DateTime Year { get; set; }
        public short Shift { get; set; }
    }
}
