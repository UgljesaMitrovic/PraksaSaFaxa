namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UbacivanjePodatakaStudenti : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT [dbo].[Students] ON");
            Sql("INSERT INTO [dbo].[Students] ([Id], [Ime], [Prezime], [Email], [Fakultet], [Smer], [StepenStudija], [Prosek], [Grad]) VALUES (1, N'Marko', N'Markovic', NULL, N'Elektronski fakultet', N'RII', N'osnovne', 8.5, N'Nis')");
            Sql("INSERT INTO [dbo].[Students] ([Id], [Ime], [Prezime], [Email], [Fakultet], [Smer], [StepenStudija], [Prosek], [Grad]) VALUES (2, N'Jovana', N'Jovic', NULL, N'Masinski', N'RII', N'master', 9, N'Beograd')");
            Sql("INSERT INTO [dbo].[Students] ([Id], [Ime], [Prezime], [Email], [Fakultet], [Smer], [StepenStudija], [Prosek], [Grad]) VALUES (3, N'Petar', N'Peric', NULL, N'Elektronski fakultet', N'RII', N'osnovne', 7.5, N'Nis')");
            Sql("SET IDENTITY_INSERT [dbo].[Students] OFF");



        }

        public override void Down()
        {
        }
    }
}
