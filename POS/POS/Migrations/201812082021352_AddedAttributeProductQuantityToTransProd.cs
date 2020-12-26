namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttributeProductQuantityToTransProd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransProds", "ProductQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransProds", "ProductQuantity");
        }
    }
}
