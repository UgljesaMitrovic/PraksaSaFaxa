namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromenaModelaOglas1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oglas", "Potvrdjen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oglas", "Potvrdjen");
        }
    }
}
