namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalUserFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "EmailAddress", c => c.String());
            AddColumn("dbo.Person", "PrimaryPhone", c => c.String());
            AddColumn("dbo.Person", "Notes", c => c.String());
            AddColumn("dbo.Person", "HomeAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "HomeAddress");
            DropColumn("dbo.Person", "Notes");
            DropColumn("dbo.Person", "PrimaryPhone");
            DropColumn("dbo.Person", "EmailAddress");
        }
    }
}
