using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IserviceFlight
    {
        public IList<Flight> Flights = new List<Flight>();

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {

            var query = Flights.GroupBy(B => B.Destination); 
            foreach (var  item in query)
            {
                Console.WriteLine("Destination" + item.Key);
                foreach(var i in item)
                {
                    Console.WriteLine("Flight Date"+i.FlightDate); 
                }
            }
            return(query);  
        }

        public double DurationAverage(string destination)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            /*IList<DateTime> lsdate = new List<DateTime>();

             foreach (var item in Flights)
             {
                 if (item.Destination.Equals(destination))
                 {
                     lsdate.Add(item.FlightDate);
                 }
             }
          return lsdate;*/
            return from item in Flights where item.Destination == destination select item.FlightDate;
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            throw new NotImplementedException();
        }

        public int ProgrammedFlightNumber(DateTime StartDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void ShowFlightDetails(Plane plane)
            
        {
            var Query = from item in Flights where item.Plane == plane select new { item.FlightDate, item.Destination };
            //var query = Flights.Where(B=>B.Plane == plane ).Select()
            //new {B.Destination , B.FlightDate};
            foreach (var item in Query)
            {
                Console.WriteLine(item.FlightDate + item.Destination);
            }
        }
    }
}
