using System;
using System.Collections.Generic;


namespace APPMEDICALAPPOINTMENTS.Data
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentName { get; set; }

        public Reservation Reservation { get; set; }


    }
}
