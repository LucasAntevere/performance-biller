using System.Collections.Generic;

namespace PerformanceBiller.Contracts
{
    public class InvoiceContract
    {
        public string Customer { get; set; }
        public List<PerformanceContract> Performances { get; set; }

        // Added properties.
        public int Amount { get; set; }
        public int Credits { get; set; }
    }
}
