using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.IndianTradeDb
{
    public partial class IndianWebTradeDataBaseContext : DbContext
    {
        public IndianWebTradeDataBaseContext()
        {
        }

        public IndianWebTradeDataBaseContext(DbContextOptions<IndianWebTradeDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstCatogery> MstCatogery { get; set; }
        public virtual DbSet<MstRole> MstRole { get; set; }
        public virtual DbSet<TblCart> TblCart { get; set; }
        public virtual DbSet<TblItem> TblItem { get; set; }
        public virtual DbSet<TblItemImage> TblItemImage { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-T5N0PPO;Database=IndianWebTradeDataBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstCatogery>(entity =>
            {
                entity.ToTable("mst_Catogery");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatogeryName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<MstRole>(entity =>
            {
                entity.ToTable("mstRole");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.ToTable("tblCart");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PricePerItem)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalPrice)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCart_tbl_Item");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCart_tbl_User");
            });

            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.ToTable("tbl_Item");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Discription).HasMaxLength(220);

                entity.Property(e => e.ImageUrl).HasMaxLength(250);

                entity.Property(e => e.ItemId).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Price).HasMaxLength(20);

                entity.Property(e => e.Quantity).HasMaxLength(20);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblItem)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__tbl_Item__Catego__4BAC3F29");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TblItem)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__tbl_Item__Seller__4CA06362");
            });

            modelBuilder.Entity<TblItemImage>(entity =>
            {
                entity.ToTable("tbl_ItemImage");

                entity.Property(e => e.ImageUrl).HasMaxLength(250);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.ToTable("tblOrder");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrder_tbl_Item");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrder_tbl_User");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_User");

                entity.Property(e => e.Address).HasMaxLength(140);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.ImageUrl).HasMaxLength(140);

                entity.Property(e => e.MobileNo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Password).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
