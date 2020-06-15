using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private static readonly int MinimumCostPerKiloMeter = 10;
        private static readonly int CostPerTime = 1;
        private static readonly double MinimumFare = 5;

        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MinimumCostPerKiloMeter + time * CostPerTime;
            return Math.Max(totalFare,MinimumFare);
        }

        public double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach(Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
    }
}
