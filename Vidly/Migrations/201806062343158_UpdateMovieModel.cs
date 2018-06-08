namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GenreType_Id", newName: "Genre_Id");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreType_Id", newName: "IX_Genre_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_Genre_Id", newName: "IX_GenreType_Id");
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreType_Id");
        }
    }
}
