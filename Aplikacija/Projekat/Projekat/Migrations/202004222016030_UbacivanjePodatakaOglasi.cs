namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UbacivanjePodatakaOglasi : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Oglas] ON");
            Sql("INSERT INTO [dbo].[Oglas] ([Id], [DatumPostavljanja], [Naslov], [OpisOglasa], [Firma_Id], [Student_Id]) VALUES (1, N'2020-04-20 00:00:00', N'Oglas1', N'Opis1', 1, 1)");
            Sql("INSERT INTO [dbo].[Oglas] ([Id], [DatumPostavljanja], [Naslov], [OpisOglasa], [Firma_Id], [Student_Id]) VALUES (2, N'2020-04-21 00:00:00', N'Oglas2', N'Opis2', 2, 2)");
            Sql("INSERT INTO [dbo].[Oglas] ([Id], [DatumPostavljanja], [Naslov], [OpisOglasa], [Firma_Id], [Student_Id]) VALUES (3, N'2020-04-22 00:00:00', N'Oglas3', N'Opis3', 3, 3)");
            Sql("SET IDENTITY_INSERT [dbo].[Oglas] OFF");

        }

        public override void Down()
        {
        }
    }
}
