using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int numberOfRides;
        public double totalFare;
        public double averageFare;

        /// <summary>
        /// Parametrized Constructor the initialise the values 
        /// </summary>
        /// <param name="numberOfRides">It Contains the information of Total Number Of Rides travel</param>
        /// <param name="totalFare">It Contains the Total Fare Of All Rides</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

        /// <summary>
        /// Overrides the Equal Method to Compare The values Equal or Not
        /// </summary>
        /// <param name="o">It is an Object Contains the information of Invoice Summary</param>
        /// <returns>It returns the Number of rides</returns>
        public override bool Equals(Object o)
        {
            //It checks for the Object
            if (this == o) return true;
            //It checks for object if null or object type is not equal then return false
            if (o == null || !this.GetType().Equals(o.GetType())) return false;
            //It Check for the Both Object And Invoice summary are Equal 
            InvoiceSummary that = (InvoiceSummary) o;
            return numberOfRides == that.numberOfRides &&
                totalFare.CompareTo(that.totalFare) == 0 &&
                averageFare.CompareTo(that.averageFare) == 0;
        }
    }
}
