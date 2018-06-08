namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldToMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreType_Id" });
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "GenreType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreType_Id");
            AddForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreType_Id" });
            AlterColumn("dbo.Movies", "GenreType_Id", c => c.Int());
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            CreateIndex("dbo.Movies", "GenreType_Id");
            AddForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres", "Id");
        }
    }
}
