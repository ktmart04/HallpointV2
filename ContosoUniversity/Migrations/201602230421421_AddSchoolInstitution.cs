namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchoolInstitution : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolInstitution",
                c => new
                    {
                        SchoolInstitutionID = c.String(nullable: false, maxLength: 128),
                        SchoolName = c.String(),
                        SchoolAddress = c.String(),
                        SchoolPhone = c.String(),
                    })
                .PrimaryKey(t => t.SchoolInstitutionID);
            
            AddColumn("dbo.Department", "School_SchoolInstitutionID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Department", "School_SchoolInstitutionID");
            AddForeignKey("dbo.Department", "School_SchoolInstitutionID", "dbo.SchoolInstitution", "SchoolInstitutionID");
            AlterStoredProcedure(
                "dbo.Department_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        InstructorID = p.Int(),
                        School_SchoolInstitutionID = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[Department]([Name], [Budget], [StartDate], [InstructorID], [School_SchoolInstitutionID])
                      VALUES (@Name, @Budget, @StartDate, @InstructorID, @School_SchoolInstitutionID)
                      
                      DECLARE @DepartmentID int
                      SELECT @DepartmentID = [DepartmentID]
                      FROM [dbo].[Department]
                      WHERE @@ROWCOUNT > 0 AND [DepartmentID] = scope_identity()
                      
                      SELECT t0.[DepartmentID], t0.[RowVersion]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentID] = @DepartmentID"
            );
            
            AlterStoredProcedure(
                "dbo.Department_Update",
                p => new
                    {
                        DepartmentID = p.Int(),
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        InstructorID = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        School_SchoolInstitutionID = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [dbo].[Department]
                      SET [Name] = @Name, [Budget] = @Budget, [StartDate] = @StartDate, [InstructorID] = @InstructorID, [School_SchoolInstitutionID] = @School_SchoolInstitutionID
                      WHERE (([DepartmentID] = @DepartmentID) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))
                      
                      SELECT t0.[RowVersion]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentID] = @DepartmentID"
            );
            
            AlterStoredProcedure(
                "dbo.Department_Delete",
                p => new
                    {
                        DepartmentID = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        School_SchoolInstitutionID = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Department]
                      WHERE ((([DepartmentID] = @DepartmentID) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL))) AND (([School_SchoolInstitutionID] = @School_SchoolInstitutionID) OR ([School_SchoolInstitutionID] IS NULL AND @School_SchoolInstitutionID IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Department", "School_SchoolInstitutionID", "dbo.SchoolInstitution");
            DropIndex("dbo.Department", new[] { "School_SchoolInstitutionID" });
            DropColumn("dbo.Department", "School_SchoolInstitutionID");
            DropTable("dbo.SchoolInstitution");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
