namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NNVezaStudentToOglas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oglas", "Student_Id", "dbo.Students");
            DropIndex("dbo.Oglas", new[] { "Student_Id" });
            CreateTable(
                "dbo.StudentToOglas",
                c => new
                    {
                        StudentToOglasId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        OglasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentToOglasId)
                .ForeignKey("dbo.Oglas", t => t.OglasId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.OglasId);
            
            DropColumn("dbo.Oglas", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oglas", "Student_Id", c => c.Int());
            DropForeignKey("dbo.StudentToOglas", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentToOglas", "OglasId", "dbo.Oglas");
            DropIndex("dbo.StudentToOglas", new[] { "OglasId" });
            DropIndex("dbo.StudentToOglas", new[] { "StudentId" });
            DropTable("dbo.StudentToOglas");
            CreateIndex("dbo.Oglas", "Student_Id");
            AddForeignKey("dbo.Oglas", "Student_Id", "dbo.Students", "Id");
        }
    }
}
