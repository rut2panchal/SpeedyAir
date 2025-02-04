using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir
{
    /**
     * Flight class conatins information about flight number, departure, arrival and day.
     * It also has the ability to store orders using 'Orders' property.
     */
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }
        // List to store assigned orders
        public List<Order> Orders { get; set; }

        /**
         * Constructor to initialize the Flight class with required params. 
         */
        public Flight(int flightNumber, string departure, string arrival, int day)
        {
            FlightNumber = flightNumber;
            Departure = departure;
            Arrival = arrival;
            Day = day;
            Orders = new List<Order>();
        }

        /**
         * Display the flight schedule
         */
        public void DisplaySchedule()
        {

            Console.WriteLine(
                $"Flight: {FlightNumber}, " +
                $"Departure: {Departure}, " +
                $"Arrival: {Arrival}, " +
                $"Day: {Day}"
            );
        }
    }
}
