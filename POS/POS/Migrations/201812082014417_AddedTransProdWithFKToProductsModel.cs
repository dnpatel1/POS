namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransProdWithFKToProductsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransProds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransProds", "ProductId", "dbo.Products");
            DropIndex("dbo.TransProds", new[] { "ProductId" });
            DropTable("dbo.TransProds");
        }
    }
}
