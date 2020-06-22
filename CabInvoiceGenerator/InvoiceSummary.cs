//-----------------------------------------------------------------------
// <copyright file="InvoiceSummary.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// This Class Gives the Summary of invoice
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// It stores the Number Of Rides
        /// </summary>
        private int numberOfRides;

        /// <summary>
        /// It stores the total Fare
        /// </summary>
        private double totalFare;

        /// <summary>
        /// It stores the average Fare
        /// </summary>
        private double averageFare;

        /// <summary>
        /// Parameterized Constructor it initializes the values 
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
        /// <param name="obj">It is an Object Contains the information of Invoice Summary</param>
        /// <returns>It returns the Number of rides</returns>
        public override bool Equals(object obj)
        {
            // It checks for the Object
            if (this == obj) 
            { 
                return true;
            }

            // It checks for object if null or object type is not equal then return false
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            // It Check for the Both Object And Invoice summary are Equal 
            InvoiceSummary that = (InvoiceSummary)obj;
            return this.numberOfRides == that.numberOfRides &&
                this.totalFare.CompareTo(that.totalFare) == 0 &&
                this.averageFare.CompareTo(that.averageFare) == 0;
        }
    }
}
