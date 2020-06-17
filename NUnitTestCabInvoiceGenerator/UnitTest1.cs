namespace NUnitTestCabInvoiceGenerator
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// This Class Contains the Test Cases used to check the functionality of Cab Invoice Generator
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Create instance of InvoiceService Globally
        /// </summary>
        private InvoiceService invoiceService = null;

        /// <summary>
        /// Initialize the instance of InvoiceService
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Given Distance and Time Returns The Total Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = this.invoiceService.CalculateFare(InvoiceService.Journey.NORMAL, distance, time);
            double expectedFare = 25;
            Assert.AreEqual(expectedFare, fare);
        }

        /// <summary>
        /// Given Less Distance And Time Returns The Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = this.invoiceService.CalculateFare(InvoiceService.Journey.NORMAL, distance, time);
            double expectedFare = 5;
            Assert.AreEqual(expectedFare, fare);
        }

        /// <summary>
        /// Given Multiple Rides Returns the Total Number Of Rides,Total Fare (Invoice Summary)
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] rides = 
                           { 
                             new Ride(InvoiceService.Journey.NORMAL, 2.0, 5),
                             new Ride(InvoiceService.Journey.NORMAL, 0.1, 1)
                           };
            InvoiceSummary summary = this.invoiceService.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given UserId And Rides Returns the Invoice Summary
        /// </summary>
        [Test]
        public void GivenUserIdAndRide_ShouldReturnInvoiceSummary()
        {
            string userId = "abc@gmail.com";
            Ride[] rides = 
                            { 
                             new Ride(InvoiceService.Journey.NORMAL, 2.0, 5),
                             new Ride(InvoiceService.Journey.NORMAL, 0.1, 1)
                            };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given More Rides and UserId returns the Invoice Summary
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            string userId = "abc@gmail.com";
            Ride[] rides = 
                            {
                             new Ride(InvoiceService.Journey.NORMAL, 2.0, 5), // 25
                             new Ride(InvoiceService.Journey.NORMAL, 3.0, 5), // 35
                             new Ride(InvoiceService.Journey.NORMAL, 4.0, 5), // 45
                             new Ride(InvoiceService.Journey.NORMAL, 5.0, 10) // 60
                            };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(4, 165.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given More Rides and Empty UserId returns the Exception
        /// </summary>
        [Test]
        public void GivenEmptyUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            try
            {
                string userId = string.Empty;
                Ride[] rides = 
                               {
                                 new Ride(InvoiceService.Journey.NORMAL, 2.0, 5), // 25
                                 new Ride(InvoiceService.Journey.NORMAL, 5.0, 10) // 60
                               };
                this.invoiceService.AddRides(userId, rides);
                InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 85.0);
            }
            catch (CabInvoiceException e)
            {
                Assert.AreEqual(CabInvoiceException.ExceptionType.ValueCanNotBeEmpty, e.type);
            }
        }

        /// <summary>
        /// Given More Rides and Null UserId returns the Exception
        /// </summary>
        [Test]
        public void GivenNullUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            try
            {
                string userId = null;
                Ride[] rides = 
                               {
                                 new Ride(InvoiceService.Journey.NORMAL, 2.0, 5), // 25
                                 new Ride(InvoiceService.Journey.NORMAL, 3.0, 5) // 35
                               };
                this.invoiceService.AddRides(userId, rides);
                InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            }
            catch (CabInvoiceException e)
            {
                Assert.AreEqual(CabInvoiceException.ExceptionType.ValueCanNotBeNull, e.type);
            }
        }

        /// <summary>
        /// Given JourneyType,UserId and No Rides returns the Invoice Summary
        /// </summary>
        [Test]
        public void GivenJourneyTypeUserIdAndNoRides_ShouldReturnInvoiceSummary()
        {
            string userId = "abc@gmail.com";
            Ride[] rides = { };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(0, 0.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given JourneyType,UserId and number of Rides returns the Invoice Summary
        /// </summary>
        [Test]
        public void GivenJourneyTypeUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            string userId = "abc@gmail.com";
            Ride[] rides = 
                            {
                             new Ride(InvoiceService.Journey.PREMIUM, 2.0, 5), // 40
                             new Ride(InvoiceService.Journey.NORMAL, 3.0, 5), // 35
                             new Ride(InvoiceService.Journey.PREMIUM, 4.0, 5), // 70
                             new Ride(InvoiceService.Journey.NORMAL, 5.0, 10) // 60
                            };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(4, 205.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}