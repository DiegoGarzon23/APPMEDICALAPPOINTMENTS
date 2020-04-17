namespace APPMEDICALAPPOINTMENTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identification = c.String(),
                        IdMedicNumber = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Adress = c.String(),
                        ImageUrl = c.String(),
                        RegisteredMedicDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Observations = c.String(),
                        MessageDescription = c.String(),
                        AppointmentDate = c.DateTime(nullable: false),
                        IdPatient = c.Int(nullable: false),
                        IdMedicNumber = c.Int(nullable: false),
                        PatientSystoms = c.String(),
                        PatientSick = c.String(),
                        Medicaments = c.String(),
                        IdUserNumer = c.Int(nullable: false),
                        PriceAppointment = c.Int(nullable: false),
                        IdStatusPayment = c.Int(nullable: false),
                        IdStatusAppointment = c.Int(nullable: false),
                        Medic_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medics", t => t.Medic_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Medic_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identification = c.String(),
                        IdNumber = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Adress = c.String(),
                        ImageUrl = c.String(),
                        Sick = c.String(),
                        Medicaments = c.String(),
                        Alergy = c.String(),
                        RegisteredPatientDate = c.DateTime(nullable: false),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Activated = c.Boolean(nullable: false),
                        UserAdministrator = c.Boolean(nullable: false),
                        UserCreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Status", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Payments", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Pacients", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Medic_Id", "dbo.Medics");
            DropForeignKey("dbo.Medics", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Status", new[] { "Reservation_Id" });
            DropIndex("dbo.Payments", new[] { "Reservation_Id" });
            DropIndex("dbo.Pacients", new[] { "Reservation_Id" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropIndex("dbo.Reservations", new[] { "Medic_Id" });
            DropIndex("dbo.Medics", new[] { "Category_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Status");
            DropTable("dbo.Payments");
            DropTable("dbo.Pacients");
            DropTable("dbo.Reservations");
            DropTable("dbo.Medics");
            DropTable("dbo.Categories");
        }
    }
}
