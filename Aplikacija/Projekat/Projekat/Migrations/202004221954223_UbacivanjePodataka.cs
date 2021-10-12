namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UbacivanjePodataka : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Firmas] ON");
            Sql("INSERT INTO [dbo].[Firmas] ([Id], [Ime], [Grad]) VALUES (1, N'Codeus', N'Nis')");
            Sql("INSERT INTO [dbo].[Firmas] ([Id], [Ime], [Grad]) VALUES (2, N'MMS', N'Nis')");
            Sql("INSERT INTO[dbo].[Firmas]([Id], [Ime], [Grad]) VALUES(3, N'Quantox', N'Beograd')");
            Sql("SET IDENTITY_INSERT [dbo].[Firmas] OFF");

        }

        public override void Down()
        {
        }
    }
}
