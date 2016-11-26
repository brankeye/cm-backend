namespace cm.backend.domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAttending = c.Boolean(nullable: false),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        ClassId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ClassId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Day = c.String(),
                        StartTime = c.DateTimeOffset(nullable: false, precision: 7),
                        EndTime = c.DateTimeOffset(nullable: false, precision: 7),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CanceledClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Time = c.DateTimeOffset(nullable: false, precision: 7),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.EvaluationSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Body = c.String(),
                        Score = c.Single(nullable: false),
                        EvaluationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evaluations", t => t.EvaluationId)
                .Index(t => t.EvaluationId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        IsTeacher = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.ProfileId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Members", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Members", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.EvaluationSections", "EvaluationId", "dbo.Evaluations");
            DropForeignKey("dbo.Evaluations", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.CanceledClasses", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.AttendanceRecords", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.AttendanceRecords", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Users", new[] { "ProfileId" });
            DropIndex("dbo.Members", new[] { "SchoolId" });
            DropIndex("dbo.Members", new[] { "ProfileId" });
            DropIndex("dbo.EvaluationSections", new[] { "EvaluationId" });
            DropIndex("dbo.Evaluations", new[] { "ProfileId" });
            DropIndex("dbo.CanceledClasses", new[] { "ClassId" });
            DropIndex("dbo.Classes", new[] { "SchoolId" });
            DropIndex("dbo.AttendanceRecords", new[] { "ProfileId" });
            DropIndex("dbo.AttendanceRecords", new[] { "ClassId" });
            DropTable("dbo.Users");
            DropTable("dbo.Members");
            DropTable("dbo.EvaluationSections");
            DropTable("dbo.Evaluations");
            DropTable("dbo.CanceledClasses");
            DropTable("dbo.Profiles");
            DropTable("dbo.Schools");
            DropTable("dbo.Classes");
            DropTable("dbo.AttendanceRecords");
        }
    }
}
