namespace Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersianMG : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        GoodsID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Barcode = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.GoodsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inventory");
        }
    }
}
