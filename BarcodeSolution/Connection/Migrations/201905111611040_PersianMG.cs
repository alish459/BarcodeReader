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
                })
                .PrimaryKey(t => t.RowID);
            CreateTable(
                "dbo.TblInventory",
                c => new
                {
                    Shka = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Shka);
        }

        public override void Down()
        {
            DropTable("dbo.TblBarcode");
            DropTable("dbo.TblInventory");
        }

    }
}
