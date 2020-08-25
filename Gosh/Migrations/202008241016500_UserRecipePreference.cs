namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRecipePreference : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRecipePreferences",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRecipePreferences", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserRecipePreferences", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.UserRecipePreferences", new[] { "RecipeID" });
            DropIndex("dbo.UserRecipePreferences", new[] { "UserID" });
            DropTable("dbo.UserRecipePreferences");
        }
    }
}
