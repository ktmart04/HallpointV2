namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateReportCardLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "ReportCardURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "ReportCardURL");
        }
    }
}
