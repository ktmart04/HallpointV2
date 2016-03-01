namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyLOT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LOTPointTracker", "LOTStudent_ID", "dbo.Person");
            DropIndex("dbo.LOTPointTracker", new[] { "LOTStudent_ID" });
            RenameColumn(table: "dbo.LOTPointTracker", name: "LOTStudent_ID", newName: "StudentID");
            AlterColumn("dbo.LOTPointTracker", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.LOTPointTracker", "StudentID");
            AddForeignKey("dbo.LOTPointTracker", "StudentID", "dbo.Person", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOTPointTracker", "StudentID", "dbo.Person");
            DropIndex("dbo.LOTPointTracker", new[] { "StudentID" });
            AlterColumn("dbo.LOTPointTracker", "StudentID", c => c.Int());
            RenameColumn(table: "dbo.LOTPointTracker", name: "StudentID", newName: "LOTStudent_ID");
            CreateIndex("dbo.LOTPointTracker", "LOTStudent_ID");
            AddForeignKey("dbo.LOTPointTracker", "LOTStudent_ID", "dbo.Person", "ID");
        }
    }
}
