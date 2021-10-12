namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromenaModelaOglas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oglas", "Tehnologije", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oglas", "Tehnologije");
        }
    }
}
