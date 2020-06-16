using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// This Class is used to initialise new Ride
    /// </summary>
    public class Ride
    {
        public double distance;
        public int time;

        /// <summary>
        /// Parametrized Constructor to initialise the Values of New Ride
        /// </summary>
        /// <param name="distance">Parameter stored the total address travel</param>
        /// <param name="time">Parameter stored the time</param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
