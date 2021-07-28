using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyNongSan.Models
{
    public partial class NongSanVN : DbContext
    {
        public NongSanVN()
            : base("name=NongSanVN")
        {
        }

        public virtual DbSet<Custormer> Custormers { get; set; }
        public virtual DbSet<LoaiN> LoaiNS { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NongSan> NongSans { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Custormer>()
                .Property(e => e.cusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Custormer>()
                .Property(e => e.cusEmail)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiN>()
                .HasMany(e => e.NongSans)
                .WithRequired(e => e.LoaiN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.TinTucs)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<NongSan>()
                .Property(e => e.Price)
                .IsUnicode(false);

            modelBuilder.Entity<NongSan>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.NongSan)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.orderID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.cusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.orderDateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ThanhTien)
                .IsUnicode(false);
        }
    }
}
