using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private static readonly int MinimumCostPerKiloMeter = 10;
        private static readonly int CostPerTime = 1;

        public double CalculateFare(double distance, int time)
        {
            return distance *  MinimumCostPerKiloMeter + time * CostPerTime;
        }
    }
}
