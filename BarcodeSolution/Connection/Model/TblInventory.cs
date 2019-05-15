namespace Connection.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblInventory")]
    public class TblInventory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Shka { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        public ICollection<TblBarcode> TblBarcodes { get; set; }
    }
}
