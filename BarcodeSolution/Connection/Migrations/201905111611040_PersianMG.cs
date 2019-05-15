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
                    GoodsID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 500),
                    Barcode1 = c.String(maxLength: 500),
                    Barcode2 = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.RowID);

        }

        public override void Down()
        {
            DropTable("dbo.TblBarcode");
        }
    }
}
