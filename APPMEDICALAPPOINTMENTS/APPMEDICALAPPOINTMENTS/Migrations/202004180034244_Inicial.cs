namespace APPMEDICALAPPOINTMENTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Price");
        }
    }
}
