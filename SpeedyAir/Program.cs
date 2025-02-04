using Newtonsoft.Json;
using SpeedyAir;

public class Program
{
    public static void Main(string[] args)
    {
        // Read content of the JSON file into string variable.
        string ordersJson = File.ReadAllText("coding-assigment-orders.json");
        // Create Dictionary structure to deserialize the JSON 
        // It allows to work with individual order in the JSON.
        var orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(ordersJson);

        List<Flight> flights = FlightSchedule();

        // UserStory 1: Display Flights Schedule
        DisplayAllFlightsSchedule(flights);

        // UserStory 2: Generate flight itineraries by scheduling a batch of orders
        LoadOrdersOnFlight(orders, flights);

    }
    /**
     * Generate Flight Schedule and return it.
     */ 
    public static List<Flight> FlightSchedule()
    {
        return new List<Flight>
            {
                new Flight(1, "YUL", "YYZ", 1),
                new Flight(2, "YUL", "YYC", 1),
                new Flight(3, "YUL", "YVR", 1),
                new Flight(4, "YUL", "YYZ", 2),
                new Flight(5, "YUL", "YYC", 2),
                new Flight(6, "YUL", "YVR", 2),
            };
    }

    /**
     * Display all flights schedules using Flight class DisplaySchedule method.
     */ 
    public static void DisplayAllFlightsSchedule(List<Flight> flights)
    {
        Console.WriteLine("Flights Schedule:");
        foreach (var flight in flights)
        {
            flight.DisplaySchedule();
        }
    }

    /**
     * Assign and manage orders on each flight based on flight capacity.
     */ 
    public static void LoadOrdersOnFlight(Dictionary<string, Order> orders, List<Flight> flights)
    {
        Console.WriteLine("\nAssigned Orders:");
        const int FLIGHT_CAPACITY = 20; // Each plane has a capacity of 20 boxes each. 

        // Loop through each order in the dictionary
        foreach (var orderKey in orders.Keys)
        {
            bool assigned = false; // Flag to check if an order has been assigned

            // Iterate through each flight to find a suitable one for the order
            foreach (var flight in flights)
            {
                // Check if the flight goes to the order's destination and has available space
                if (flight.Arrival == orders[orderKey].Destination && flight.Orders.Count < FLIGHT_CAPACITY)
                {
                    flight.Orders.Add(orders[orderKey]);
                    Console.WriteLine($"Order: {orderKey}, FlightNumber: {flight.FlightNumber}, Departure: {flight.Departure}, Arrival: {flight.Arrival}, Day: {flight.Day}");
                    assigned = true;
                    break;
                }
            }
            // If no suitable flight was found, order is marked as "not scheduled"
            if (!assigned)
            {
                Console.WriteLine($"Order: {orderKey}, FlightNumber: not scheduled");
            }
        }
    }
}