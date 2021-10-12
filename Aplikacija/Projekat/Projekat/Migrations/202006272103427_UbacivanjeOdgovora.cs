namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UbacivanjeOdgovora : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Odgovors] ON");
            Sql("INSERT INTO [dbo].[Odgovors] ([Id], [Tekst], [Datum], [Post_Id], [Student_Id]) VALUES (1, N'Meni je super.', N'2020-06-25 00:00:00', N'1', N'1')");
            Sql("INSERT INTO [dbo].[Odgovors] ([Id], [Tekst], [Datum], [Post_Id], [Student_Id]) VALUES (2, N'Svidja mi se takodje Codeus', N'2020-06-25 00:00:00', N'2', N'2')");
            Sql("INSERT INTO [dbo].[Odgovors] ([Id], [Tekst], [Datum], [Post_Id], [Student_Id]) VALUES (3, N'Meni je bilo odlicno.', N'2020-06-25 00:00:00', N'3', N'3')");
            Sql("SET IDENTITY_INSERT [dbo].[Odgovors] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
