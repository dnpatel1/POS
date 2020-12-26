namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKToTransactionModelFromTransProd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransProds", "TransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransProds", "TransactionId");
            AddForeignKey("dbo.TransProds", "TransactionId", "dbo.Transactions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransProds", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.TransProds", new[] { "TransactionId" });
            DropColumn("dbo.TransProds", "TransactionId");
        }
    }
}
