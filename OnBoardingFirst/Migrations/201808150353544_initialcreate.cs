namespace OnBoardingFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductSolds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        DateSold = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSolds", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.ProductSolds", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductSolds", "CustomerID", "dbo.Customers");
            DropIndex("dbo.ProductSolds", new[] { "StoreID" });
            DropIndex("dbo.ProductSolds", new[] { "CustomerID" });
            DropIndex("dbo.ProductSolds", new[] { "ProductID" });
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
            DropTable("dbo.ProductSolds");
            DropTable("dbo.Customers");
        }
    }
}
