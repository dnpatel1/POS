namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartadded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "cart_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "cart_id");
        }
    }
}
