using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_Analysis.Models
{
    public class TimePeriod
    {
        public TimePeriod(string selectedYear)
        {
            Start = new DateTime(int.Parse(selectedYear), 1, 1);
            End = new DateTime(int.Parse(selectedYear), 12, 31);
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
