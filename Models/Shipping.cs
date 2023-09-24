using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class Shipping
    {
        public string? DestinationLand { get; set; }
        public decimal Quantity { get; set; }
        public decimal Percentage { get; set; }
    }
}
