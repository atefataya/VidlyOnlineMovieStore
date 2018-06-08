namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES (Name) VALUES('Hangover')");
            Sql("INSERT INTO MOVIES (Name) VALUES('Die Hard')");
            Sql("INSERT INTO MOVIES (Name) VALUES('The Terminator')");
            Sql("INSERT INTO MOVIES (Name) VALUES('Toy Story')");
            Sql("INSERT INTO MOVIES (Name) VALUES('Titanic')");

        }

        public override void Down()
        {
        }
    }
}
