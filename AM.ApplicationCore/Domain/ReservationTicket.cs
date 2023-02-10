using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public  class ReservationTicket
    {
        public DateTime DateReservation { get; set; }
        public float Prix { get; set; }
        public int TicketFK { get; set; }

        public String PassengerFK  { get; set; }
        [ForeignKey("PassengerFK")]

        public Passenger  Passenger;

        [ForeignKey("TicketFK")] 
         public Ticket Ticket { get; set; }
          


    }
}
