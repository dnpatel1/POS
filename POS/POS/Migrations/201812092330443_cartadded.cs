namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Transaction_Id", c => c.Int());
            CreateIndex("dbo.Products", "Transaction_Id");
            AddForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions");
            DropIndex("dbo.Products", new[] { "Transaction_Id" });
            DropColumn("dbo.Products", "Transaction_Id");
        }
    }
}
