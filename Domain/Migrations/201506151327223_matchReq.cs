namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clubs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clubs", "Name", c => c.String());
        }
    }
}
