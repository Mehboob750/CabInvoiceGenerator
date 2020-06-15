using CabInvoiceGenerator;
using NUnit.Framework;

namespace NUnitTestCabInvoiceGenerator
{
    public class Tests
    {
        public InvoiceGenerator invoiceGenerator = null;

        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
        }

        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance,time);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, fare);
        }

        [Test]
        public void GivenMultipleRides_ShouldReturnTotalFare()
        {
            Ride[] rides = { new Ride(2.0,5),
                            new Ride(0.1,1)};
            double fare = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(30, fare);
        }

    }
}