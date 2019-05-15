namespace Connection.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblBarcoed")]
    public partial class TblBarcode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowID { get; set; }

        [Required]
        public int Shka { get; set; }

        [StringLength(500)]
        public string Barcode1 { get; set; }

        [StringLength(500)]
        public string Barcode2 { get; set; }

        [ForeignKey("Shka")]
        public TblInventory Inventories { get; set; }
    }
}
