using CabInvoiceGenerator;
using NUnit.Framework;

namespace NUnitTestCabInvoiceGenerator
{
    public class Tests
    {
        //Create instance of InvoiceService Globally
        public InvoiceService invoiceService = null;

        /// <summary>
        /// Initialise the instance of IvoiceService
        /// </summary>
        [SetUp]
        public void Setup()
        {
            invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Given Distance and Time Returns The Total Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = invoiceService.CalculateFare(distance,time);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// Given Less Distance And Time Returns The Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = invoiceService.CalculateFare(distance, time);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// Given Multiple Rides Returns the Total Number Of Rides,Total Fare (Invoice Summary)
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] rides = { new Ride(2.0,5),
                             new Ride(0.1,1)
                            };
            InvoiceSummary summary = invoiceService.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary= new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given UserId And Rides Returns the Invoice Summary
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            string userId = "abc@gmail.com";
            Ride[] rides = { new Ride(2.0,5),
                             new Ride(0.1,1)
                            };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}