namespace CabInvoiceGenerator
{
    /// <summary>
    /// This Class is used to initialize new Ride
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// It contains the Type of Journey
        /// </summary>
        public InvoiceService.Journey journey;

        /// <summary>
        /// It contains the Distance
        /// </summary>
        public double distance;

        /// <summary>
        /// It contains the time
        /// </summary>
        public int time;

        /// <summary>
        /// Parameterized Constructor to initialize the Values of New Ride
        /// </summary>
        /// <param name="journey">Parameter stored the type of journey</param>
        /// <param name="distance">Parameter stored the total address travel</param>
        /// <param name="time">Parameter stored the time</param>
        public Ride(InvoiceService.Journey journey, double distance, int time)
        {
            this.journey = journey;
            this.distance = distance;
            this.time = time;
        }
    }
}
