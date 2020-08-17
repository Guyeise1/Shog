namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repsrentig_City_in_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "RepresetingCity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "RepresetingCity");
        }
    }
}
