namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForiegnKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.UserRecipePreferences", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.Recipes", new[] { "Category_ID" });
            DropIndex("dbo.UserRecipePreferences", new[] { "RecipeID" });
            DropColumn("dbo.Recipes", "CategoryId");
            RenameColumn(table: "dbo.Recipes", name: "Category_ID", newName: "CategoryId");
            DropPrimaryKey("dbo.Recipes");
            AlterColumn("dbo.Recipes", "RecipeId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Recipes", "CategoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.Recipes", "CategoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.UserRecipePreferences", "RecipeID", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Recipes", "RecipeId");
            CreateIndex("dbo.Recipes", "CategoryId");
            CreateIndex("dbo.UserRecipePreferences", "RecipeID");
            AddForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserRecipePreferences", "RecipeID", "dbo.Recipes", "RecipeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRecipePreferences", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserRecipePreferences", new[] { "RecipeID" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Recipes");
            AlterColumn("dbo.UserRecipePreferences", "RecipeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipes", "CategoryId", c => c.Long());
            AlterColumn("dbo.Recipes", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipes", "RecipeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Recipes", "RecipeId");
            RenameColumn(table: "dbo.Recipes", name: "CategoryId", newName: "Category_ID");
            AddColumn("dbo.Recipes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserRecipePreferences", "RecipeID");
            CreateIndex("dbo.Recipes", "Category_ID");
            AddForeignKey("dbo.UserRecipePreferences", "RecipeID", "dbo.Recipes", "RecipeId", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
