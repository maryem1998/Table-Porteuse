using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {         // public int Id { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [MinLength(3, ErrorMessage = "invalide"), MaxLength(25)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        //ou [Range(0, 8)]
        public int? TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        //ou[EmailAddress]
        public string? EmailAddress { get; set; }
        public IList<Flight> Flights { get; set; }

        public IList<ReservationTicket> ReservationTickets { get; set; }
        public override string ToString()
        {
            return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: " + BirthDate;
        }
        public bool CheckProfile(string firstName, string lastName)
        {
            return firstName == FirstName && lastName == LastName;
        }
        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return firstName == FirstName && lastName == LastName && email.Equals(EmailAddress);
        }
        public bool login(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return firstName == FirstName && lastName == LastName && email.Equals(EmailAddress);
            return firstName == FirstName && lastName == LastName;
        }         //ploy par héritage
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger»");
        }
    }
}

