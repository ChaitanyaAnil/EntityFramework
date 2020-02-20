namespace EFCodeFirstDemoTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createcustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        Cname = c.String(nullable: false, maxLength: 250),
                        Mobileno = c.Long(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Cid);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Cid = c.Int(nullable: false),
                        Pid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Cid, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Pid, cascadeDelete: true)
                .Index(t => t.Cid)
                .Index(t => t.Pid);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Pid = c.Int(nullable: false, identity: true),
                        Pname = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Pid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "Pid", "dbo.Product");
            DropForeignKey("dbo.Purchase", "Cid", "dbo.Customer");
            DropIndex("dbo.Purchase", new[] { "Pid" });
            DropIndex("dbo.Purchase", new[] { "Cid" });
            DropTable("dbo.Product");
            DropTable("dbo.Purchase");
            DropTable("dbo.Customer");
        }
    }
}
