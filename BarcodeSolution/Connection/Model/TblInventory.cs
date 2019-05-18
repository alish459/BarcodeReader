namespace Connection.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblInventory")]
    public partial class TblInventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblInventory()
        {
            TblBarcode = new HashSet<TblBarcode>();
        }

        [Key]
        public int Shka { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Explain { get; set; }

        public decimal? Forosh { get; set; }

        public decimal? Kharid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblBarcode> TblBarcode { get; set; }
    }
}
