namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Played = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Won = c.Int(nullable: false),
                        Drawn = c.Int(nullable: false),
                        Lost = c.Int(nullable: false),
                        GoalsFor = c.Int(nullable: false),
                        GoalsAgainst = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                        HomeClubId = c.Int(nullable: false),
                        AwayClubId = c.Int(nullable: false),
                        AwayClub_ClubId = c.Int(),
                        HomeClub_ClubId = c.Int(),
                        Club_ClubId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Clubs", t => t.AwayClub_ClubId)
                .ForeignKey("dbo.Clubs", t => t.HomeClub_ClubId)
                .ForeignKey("dbo.Clubs", t => t.Club_ClubId)
                .Index(t => t.AwayClub_ClubId)
                .Index(t => t.HomeClub_ClubId)
                .Index(t => t.Club_ClubId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Time = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        ClubId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        EventKindId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Clubs", t => t.ClubId, cascadeDelete: true)
                .ForeignKey("dbo.EventKinds", t => t.EventKindId, cascadeDelete: true)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.MatchId)
                .Index(t => t.ClubId)
                .Index(t => t.PlayerId)
                .Index(t => t.EventKindId);
            
            CreateTable(
                "dbo.EventKinds",
                c => new
                    {
                        EventKindId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EventKindId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionId = c.Int(nullable: false),
                        ClubId = c.Int(nullable: false),
                        Club_ClubId = c.Int(nullable: false),
                        Club_ClubId1 = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Clubs", t => t.Club_ClubId)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Clubs", t => t.Club_ClubId1)
                .Index(t => t.PositionId)
                .Index(t => t.Club_ClubId)
                .Index(t => t.Club_ClubId1);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Club_ClubId1", "dbo.Clubs");
            DropForeignKey("dbo.Matches", "Club_ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Matches", "HomeClub_ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Events", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Players", "Club_ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Events", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Events", "EventKindId", "dbo.EventKinds");
            DropForeignKey("dbo.Events", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Matches", "AwayClub_ClubId", "dbo.Clubs");
            DropIndex("dbo.Players", new[] { "Club_ClubId1" });
            DropIndex("dbo.Players", new[] { "Club_ClubId" });
            DropIndex("dbo.Players", new[] { "PositionId" });
            DropIndex("dbo.Events", new[] { "EventKindId" });
            DropIndex("dbo.Events", new[] { "PlayerId" });
            DropIndex("dbo.Events", new[] { "ClubId" });
            DropIndex("dbo.Events", new[] { "MatchId" });
            DropIndex("dbo.Matches", new[] { "Club_ClubId" });
            DropIndex("dbo.Matches", new[] { "HomeClub_ClubId" });
            DropIndex("dbo.Matches", new[] { "AwayClub_ClubId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Players");
            DropTable("dbo.EventKinds");
            DropTable("dbo.Events");
            DropTable("dbo.Matches");
            DropTable("dbo.Clubs");
        }
    }
}
