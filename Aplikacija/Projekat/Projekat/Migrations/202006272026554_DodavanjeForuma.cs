namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DodavanjeForuma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Odgovors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Tekst = c.String(),
                    Datum = c.DateTime(nullable: false),
                    Post_Id = c.Int(),
                    Student_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Student_Id);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Tekst = c.String(),
                    Datum = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Odgovors", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Odgovors", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Odgovors", new[] { "Student_Id" });
            DropIndex("dbo.Odgovors", new[] { "Post_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Odgovors");
        }
    }
}