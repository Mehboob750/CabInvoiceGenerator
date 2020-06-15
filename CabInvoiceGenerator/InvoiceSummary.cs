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

        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

        override
        public bool Equals(Object o)
        {
            if (this == o) return true;
            if (o == null || !this.GetType().Equals(o.GetType())) return false;
            InvoiceSummary that = (InvoiceSummary) o;
            return numberOfRides == that.numberOfRides &&
                totalFare.CompareTo(that.totalFare) == 0 &&
                averageFare.CompareTo(that.averageFare) == 0;
        }
    }
}
