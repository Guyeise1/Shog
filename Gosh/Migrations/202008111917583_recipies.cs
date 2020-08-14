namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(),
                        Header = c.String(),
                        Summary = c.String(),
                        Content = c.String(),
                        HomeImageUrl = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Category_ID = c.Long(),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "Category_ID" });
            DropTable("dbo.Recipes");
        }
    }
}
