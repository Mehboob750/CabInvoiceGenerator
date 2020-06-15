using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceService
    {
        private static readonly int MinimumCostPerKiloMeter = 10;
        private static readonly int CostPerTime = 1;
        private static readonly double MinimumFare = 5;
        private RideRepository rideRepository;

        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MinimumCostPerKiloMeter + time * CostPerTime;
            return Math.Max(totalFare,MinimumFare);
        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach(Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length,totalFare);
        }

        public void AddRides(string userId, Ride[] rides)
        {
            rideRepository.AddRide(userId, rides);
        }

        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }
    }
}
