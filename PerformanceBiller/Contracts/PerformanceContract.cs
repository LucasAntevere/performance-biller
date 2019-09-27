using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceBiller.Contracts
{
    public class PerformanceContract
    {
        public string PlayId { get; set; }
        public int Audience { get; set; }

        // Added amount.
        public int Amount { get; set; }
        // Added credits;
        public int Credits { get; set; }
    }
}
