namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedArtistId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Gigs", new[] { "Artistid" });
            CreateIndex("dbo.Gigs", "ArtistId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            CreateIndex("dbo.Gigs", "Artistid");
        }
    }
}
