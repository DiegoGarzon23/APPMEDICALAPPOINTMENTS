using System;
using System.Collections.Generic;


namespace APPMEDICALAPPOINTMENTS.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        
        public ICollection<Medic> Medics { get; set; }




    }
}
