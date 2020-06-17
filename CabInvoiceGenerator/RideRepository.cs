namespace CabInvoiceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// This class is used to store the Ride information
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// Dictionary is used to store the values in key value pair,key is userId and value is number of rides
        /// </summary>
        public Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Default constructor
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// This Method is used to Add Every Ride in Ride Repository
        /// </summary>
        /// <param name="userId">It contains the userId of Passenger</param>
        /// <param name="rides">It contains the information of number of Rides</param>
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userId, list);
            }
        }

        /// <summary>
        /// This Method is Used To Fetch the Number Of Rides Based On the UserId
        /// </summary>
        /// <param name="userId">It contains userId of Passenger</param>
        /// <returns>It returns the Total Rides of that Particular UserId</returns>
        public Ride[] GetRides(string userId)
        {
            return this.userRides[userId].ToArray();
        }
    }
}
