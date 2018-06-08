namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHere SignUpFee =0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHere SignUpFee =30");
            Sql("UPDATE MembershipTypes SET Name = 'Quartly' WHere SignUpFee =90");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHere SignUpFee =300");

        }

        public override void Down()
        {
        }
    }
}
