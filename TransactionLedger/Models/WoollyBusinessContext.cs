using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransactionLedger.Models
{
    public partial class WoollyBusinessContext : DbContext
    {
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleDetail> SaleDetail { get; set; }
        public virtual DbSet<SaleSource> SaleSource { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=FRACTAL\mssqlserver01;Database=WoollyBusiness;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasIndex(e => e.SupplierId);

                entity.Property(e => e.DateOfTransaction).HasColumnType("datetime");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Supplier");
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.HasIndex(e => e.PurchaseId);

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseDetail)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDetail_Purchase");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.SaleSourceId);

                entity.Property(e => e.DateOfTransaction).HasColumnType("datetime");

                entity.HasOne(d => d.SaleSource)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.SaleSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_SaleSource");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasIndex(e => e.ItemId);

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SaleDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_SaleDetail_Sale");
            });

            modelBuilder.Entity<SaleSource>(entity =>
            {
                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
