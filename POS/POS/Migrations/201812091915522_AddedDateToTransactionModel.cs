namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToTransactionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Date");
        }
    }
}
