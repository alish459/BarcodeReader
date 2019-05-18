namespace Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersianMG : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblBarcode",
                c => new
                    {
                        RowID = c.Int(nullable: false, identity: true),
                        GoodsID = c.Int(nullable: false),
                        Barcode1 = c.String(maxLength: 500),
                        Barcode2 = c.String(maxLength: 500),
                        Explain = c.String(maxLength: 500),
                        Forosh = c.Decimal(precision: 18, scale: 0),
                        Kharid = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.RowID)
                .ForeignKey("dbo.TblInventory", t => t.GoodsID)
                .Index(t => t.GoodsID);
            
            CreateTable(
                "dbo.TblInventory",
                c => new
                    {
                        Shka = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Explain = c.String(maxLength: 500),
                        Forosh = c.Decimal(precision: 18, scale: 0),
                        Kharid = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Shka);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblBarcode", "GoodsID", "dbo.TblInventory");
            DropIndex("dbo.TblBarcode", new[] { "GoodsID" });
            DropTable("dbo.TblInventory");
            DropTable("dbo.TblBarcode");
        }
    }
}
