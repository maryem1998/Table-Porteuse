using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IserviceFlight
    {

        public IEnumerable<DateTime> GetFlightDates(string destination);

        public void ShowFlightDetails(Plane plane);

        public int ProgrammedFlightNumber(DateTime StartDate);

        public double DurationAverage(string destination);

        public IEnumerable<Flight> OrderedDurationFlights();

        public IEnumerable<Traveller> SeniorTravellers(Flight flight);

        public IEnumerable<IGrouping<String, Flight>> DestinationGroupedFlights(); 
    }
}
