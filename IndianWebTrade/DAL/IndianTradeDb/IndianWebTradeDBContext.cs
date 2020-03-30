using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.IndianTradeDb
{
    public partial class IndianWebTradeDBContext : DbContext
    {
        public IndianWebTradeDBContext()
        {
        }

        public IndianWebTradeDBContext(DbContextOptions<IndianWebTradeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstCatogery> MstCatogery { get; set; }
        public virtual DbSet<MstUserRole> MstUserRole { get; set; }
        public virtual DbSet<TblItem> TblItem { get; set; }
        public virtual DbSet<TblItemImage> TblItemImage { get; set; }
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

            modelBuilder.Entity<MstUserRole>(entity =>
            {
                entity.ToTable("mst_UserRole");

                entity.Property(e => e.RoleName).HasMaxLength(40);
            });

            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.ToTable("tbl_Item");

                entity.Property(e => e.Discription).HasMaxLength(220);

                entity.Property(e => e.ItemId).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Price).HasMaxLength(20);

                entity.Property(e => e.Quantity).HasMaxLength(20);

                entity.Property(e => e.SellerId).HasMaxLength(20);
            });

            modelBuilder.Entity<TblItemImage>(entity =>
            {
                entity.ToTable("tbl_ItemImage");

                entity.Property(e => e.ImageUrl).HasMaxLength(250);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_User");

                entity.Property(e => e.Address).HasMaxLength(140);

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.ImageUrl).HasMaxLength(140);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Password).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
