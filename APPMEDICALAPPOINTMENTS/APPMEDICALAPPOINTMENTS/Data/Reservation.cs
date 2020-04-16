using System;
using System.Collections.Generic;


namespace APPMEDICALAPPOINTMENTS.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Observations { get; set; }
        public string MessageDescription { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int IdPatient { get; set; }
        public int IdMedicNumber { get; set; }
        public string PatientSystoms { get; set; }
        public string PatientSick { get; set; }
        public string Medicaments { get; set; }
        public int IdUserNumer { get; set; }
        public int PriceAppointment { get; set; }
        public int IdStatusPayment { get; set; }
        public int IdStatusAppointment { get; set; }

        public User User { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Status> Statuses { get; set; }
        public Medic Medic { get; set; }
        public ICollection<Pacient> Pacients { get; set;}






   
    }
}
