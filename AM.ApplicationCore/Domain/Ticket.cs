using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public String Classe { get; set; }
        public String Destination { get; set; }
        public int Id { get; set; }

        public IList<ReservationTicket> ReservationTickets { get; set; }


        public Ticket()
        {

        }
        public Ticket(string classe, string destination, int id)
        {
            Classe = classe;
            Destination = destination;
            Id = id;
        }


    }
}
