using APPMEDICALAPPOINTMENTS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace APPMEDICALAPPOINTMENTS
{
    public class DataContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
