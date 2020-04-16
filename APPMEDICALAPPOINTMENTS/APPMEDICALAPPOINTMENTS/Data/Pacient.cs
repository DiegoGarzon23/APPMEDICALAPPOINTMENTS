using System;
using System.Collections.Generic;

namespace APPMEDICALAPPOINTMENTS.Data
{
    public class Pacient
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        public string Sick { get; set; }
        public string Medicaments { get; set; }
        public string Alergy { get; set; }
        public DateTime RegisteredPatientDate { get; set; }

        public Reservation Reservation { get; set; }

            








    }
}
