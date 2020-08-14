namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Hash = c.Binary(),
                        Salt = c.Binary(),
                        UserID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID, unique: true, name: "IX_PWD_USER_UNIQUE");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Mail = c.String(maxLength: 50),
                        CreditCard = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Mail, unique: true, name: "IX_Email");

           // Sql(sql:"")
            
            
        }

        public void AddDataToDB()
        {

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passwords", "UserID", "dbo.Users");
            DropIndex("dbo.Users", "IX_Email");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Passwords", "IX_PWD_USER_UNIQUE");
            DropTable("dbo.Users");
            DropTable("dbo.Passwords");
            DropTable("dbo.Categories");
        }
    }
}
