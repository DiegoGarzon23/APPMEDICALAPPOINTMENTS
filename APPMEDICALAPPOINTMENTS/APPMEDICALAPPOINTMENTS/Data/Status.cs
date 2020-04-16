using System;
using System.Collections.Generic;


namespace APPMEDICALAPPOINTMENTS.Data
{
    public class Status
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public Reservation Reservation { get; set; }

    }
}
