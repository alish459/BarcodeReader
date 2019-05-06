namespace Connection.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BarcodeEntity : DbContext
    {
        public BarcodeEntity()
            : base("name=BarcodeEntity")
        {
        }
        public virtual DbSet<Inventory> Inventory { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
