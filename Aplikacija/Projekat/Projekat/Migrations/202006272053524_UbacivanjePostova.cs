namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UbacivanjePostova : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Posts] ON");
            Sql("INSERT INTO [dbo].[Posts] ([Id], [Tekst], [Datum]) VALUES (1, N'Utisci o firmi Codues', N'2020-06-25 00:00:00')");
            Sql("INSERT INTO [dbo].[Posts] ([Id], [Tekst], [Datum]) VALUES (2, N'Firma za Python', N'2020-06-25 00:00:00')");
            Sql("INSERT INTO [dbo].[Posts] ([Id], [Tekst], [Datum]) VALUES (3, N'Utisci o firmi Nignite', N'2020-06-25 00:00:00')");
            Sql("SET IDENTITY_INSERT [dbo].[Posts] OFF");
        }


        public override void Down()
        {
        }
    }
}
