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

        /// <summary>
        /// Default Constructor Intialise the Object of RideRepository
        /// </summary>
        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// This Method is Used to Calculate Fare
        /// </summary>
        /// <param name="distance">It gives to total distance Travel</param>
        /// <param name="time">It gives the Time</param>
        /// <returns>Based on time and distance it Returns the Fare of Ride</returns>
        public double CalculateFare(double distance, int time)
        {
            //It Calculates The Total Fare Of the Ride
            double totalFare = distance * MinimumCostPerKiloMeter + time * CostPerTime;
            //Math.Max function is Used To Return the Minimum Fare if the Fare is minimum than Particular limit
            return Math.Max(totalFare,MinimumFare);
        }

        /// <summary>
        /// This Method is Used to Calculate Fare Of Multiple Rides
        /// </summary>
        /// <param name="rides">It is an array it gives the Number of Rides Travel</param>
        /// <returns>It returns the Total Fare of Rides and the Number Of Rides Travel</returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            //Foreach is used to traverse all the values of Ride
            foreach(Ride ride in rides)
            {
                //Here calculate Fare method is called to calculate fare of that particular ride and add it to total Fare
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length,totalFare);
        }

        /// <summary>
        /// This Method is Used to Add Rides in Ride Repository
        /// </summary>
        /// <param name="userId">It contains the UserId of the Passanger</param>
        /// <param name="rides">It contains the number of Rides Travel</param>
        public void AddRides(string userId, Ride[] rides)
        {
            rideRepository.AddRide(userId, rides);
        }

        /// <summary>
        /// This Method Calculate the Fare Based On Rides in the Ride Repository
        /// </summary>
        /// <param name="userId">It is Used to get the Ride Information of that UserId</param>
        /// <returns>It returns the Calculated Fare of number of Rides</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }
    }
}
