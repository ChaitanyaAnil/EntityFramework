namespace EFCodeFirstBookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Aid = c.Int(nullable: false, identity: true),
                        Aname = c.String(),
                        Address = c.String(),
                        Book_Bid = c.Int(),
                    })
                .PrimaryKey(t => t.Aid)
                .ForeignKey("dbo.Books", t => t.Book_Bid)
                .Index(t => t.Book_Bid);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Bid = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Bid);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Tid = c.Int(nullable: false, identity: true),
                        PublishDate = c.DateTime(nullable: false),
                        Bid = c.Int(nullable: false),
                        Aid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .ForeignKey("dbo.Authors", t => t.Aid, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Bid, cascadeDelete: true)
                .Index(t => t.Bid)
                .Index(t => t.Aid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "Bid", "dbo.Books");
            DropForeignKey("dbo.Details", "Aid", "dbo.Authors");
            DropForeignKey("dbo.Authors", "Book_Bid", "dbo.Books");
            DropIndex("dbo.Details", new[] { "Aid" });
            DropIndex("dbo.Details", new[] { "Bid" });
            DropIndex("dbo.Authors", new[] { "Book_Bid" });
            DropTable("dbo.Details");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
