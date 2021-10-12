namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeIdUserPropertija : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Firmas", "IdUser", c => c.String());
            AddColumn("dbo.Students", "IdUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "IdUser");
            DropColumn("dbo.Firmas", "IdUser");
        }
    }
}
