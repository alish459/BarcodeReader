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

        public virtual DbSet<TblBarcode> TblBarcode { get; set; }
        public virtual DbSet<TblInventory> TblInventory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBarcode>()
                .Property(e => e.Forosh)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TblBarcode>()
                .Property(e => e.Kharid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TblInventory>()
                .Property(e => e.Forosh)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TblInventory>()
                .Property(e => e.Kharid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TblInventory>()
                .HasMany(e => e.TblBarcode)
                .WithRequired(e => e.TblInventory)
                .HasForeignKey(e => e.GoodsID)
                .WillCascadeOnDelete(false);
        }
    }
}
