namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductModelWithoutFKToTransProd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false, maxLength: 30),
                        product_price = c.Double(nullable: false),
                        stock_remaining = c.Int(nullable: false),
                        stock_flag = c.Int(nullable: false),
                        stock_max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
