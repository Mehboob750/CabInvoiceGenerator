using CabInvoiceGenerator;
using NUnit.Framework;

namespace NUnitTestCabInvoiceGenerator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance,time);
            Assert.AreEqual(25, fare);
        }
    }
}