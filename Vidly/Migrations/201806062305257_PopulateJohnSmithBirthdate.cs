namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateJohnSmithBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='01/01/1980' WHERE Name ='John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
