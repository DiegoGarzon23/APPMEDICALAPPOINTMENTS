using System;
using System.Collections.Generic;


namespace APPMEDICALAPPOINTMENTS.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public int UserNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean Activated { get; set; }
        public Boolean UserAdministrator { get; set; }
        public DateTime UserCreationDate { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        

    }
}
