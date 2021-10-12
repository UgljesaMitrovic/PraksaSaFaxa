namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NNVezePrijavaIPoziv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pozivs",
                c => new
                    {
                        PozivId = c.Int(nullable: false, identity: true),
                        FirmaId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PozivId)
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.FirmaId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Prijavas",
                c => new
                    {
                        PrijavaId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        FirmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrijavaId)
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.FirmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prijavas", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Prijavas", "FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.Pozivs", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Pozivs", "FirmaId", "dbo.Firmas");
            DropIndex("dbo.Prijavas", new[] { "FirmaId" });
            DropIndex("dbo.Prijavas", new[] { "StudentId" });
            DropIndex("dbo.Pozivs", new[] { "StudentId" });
            DropIndex("dbo.Pozivs", new[] { "FirmaId" });
            DropTable("dbo.Prijavas");
            DropTable("dbo.Pozivs");
        }
    }
}
