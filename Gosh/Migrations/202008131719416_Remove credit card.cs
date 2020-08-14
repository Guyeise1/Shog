namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removecreditcard : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "CreditCard");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CreditCard", c => c.String());
        }
    }
}
