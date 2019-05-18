namespace Connection.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblBarcode")]
    public partial class TblBarcode
    {
        [Key]
        public int RowID { get; set; }

        public int GoodsID { get; set; }

        [StringLength(500)]
        public string Barcode1 { get; set; }

        [StringLength(500)]
        public string Barcode2 { get; set; }

        [StringLength(500)]
        public string Explain { get; set; }

        public decimal? Forosh { get; set; }

        public decimal? Kharid { get; set; }

        public virtual TblInventory TblInventory { get; set; }
    }
}
