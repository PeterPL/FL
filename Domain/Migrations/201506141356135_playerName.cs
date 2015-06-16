namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Name", c => c.String());
            DropColumn("dbo.Players", "FirstName");
            DropColumn("dbo.Players", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "LastName", c => c.String());
            AddColumn("dbo.Players", "FirstName", c => c.String());
            DropColumn("dbo.Players", "Name");
        }
    }
}
