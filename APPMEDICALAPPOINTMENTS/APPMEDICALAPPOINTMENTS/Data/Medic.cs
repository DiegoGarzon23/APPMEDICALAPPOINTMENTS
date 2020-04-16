using System;
using System.Collections.Generic;


namespace APPMEDICALAPPOINTMENTS.Data
{
    public class Medic
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public int IdMedicNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public string  Gender { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        public DateTime RegisteredMedicDate { get; set; }

        public Category Category { get; set; }
        public ICollection<Reservation> Reservations { get; set; }






    }
}
