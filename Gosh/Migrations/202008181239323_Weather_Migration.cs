namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Weather_Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "RepresetingArea", c => c.String());
            AddColumn("dbo.Categories", "WeatherHref", c => c.String());
            DropColumn("dbo.Categories", "RepresetingCity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "RepresetingCity", c => c.String());
            DropColumn("dbo.Categories", "WeatherHref");
            DropColumn("dbo.Categories", "RepresetingArea");
        }
    }
}
