namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLOTitems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOTPointTracker",
                c => new
                    {
                        LOTPointTrackerID = c.Int(nullable: false, identity: true),
                        LOTMeetingDate = c.DateTime(nullable: false),
                        AttendanceConfirmed = c.Boolean(nullable: false),
                        OnTimeConfirmed = c.Boolean(nullable: false),
                        CurrentEventsConfirmed = c.Boolean(nullable: false),
                        ParticipationConfirmed = c.Boolean(nullable: false),
                        OutsideEventConfirmed = c.Boolean(nullable: false),
                        BinderConfirmed = c.Boolean(nullable: false),
                        LOTStudent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.LOTPointTrackerID)
                .ForeignKey("dbo.Person", t => t.LOTStudent_ID)
                .Index(t => t.LOTStudent_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOTPointTracker", "LOTStudent_ID", "dbo.Person");
            DropIndex("dbo.LOTPointTracker", new[] { "LOTStudent_ID" });
            DropTable("dbo.LOTPointTracker");
        }
    }
}
