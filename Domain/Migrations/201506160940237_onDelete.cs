namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "Club_ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Matches", "AwayClub_ClubId", "dbo.Clubs");
            DropIndex("dbo.Matches", new[] { "Club_ClubId" });
            DropColumn("dbo.Matches", "AwayClub_ClubId");
            RenameColumn(table: "dbo.Matches", name: "Club_ClubId", newName: "AwayClub_ClubId");
            AddForeignKey("dbo.Matches", "AwayClub_ClubId", "dbo.Clubs", "ClubId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "AwayClub_ClubId", "dbo.Clubs");
            RenameColumn(table: "dbo.Matches", name: "AwayClub_ClubId", newName: "Club_ClubId");
            AddColumn("dbo.Matches", "AwayClub_ClubId", c => c.Int());
            CreateIndex("dbo.Matches", "Club_ClubId");
            AddForeignKey("dbo.Matches", "AwayClub_ClubId", "dbo.Clubs", "ClubId");
            AddForeignKey("dbo.Matches", "Club_ClubId", "dbo.Clubs", "ClubId");
        }
    }
}
