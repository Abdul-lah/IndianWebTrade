using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.DAL
{
    public partial class CvDataBaseContext : DbContext
    {
        public CvDataBaseContext()
        {
        }

        public CvDataBaseContext(DbContextOptions<CvDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblItem> TblItem { get; set; }
        public virtual DbSet<TblMsg> TblMsg { get; set; }
        public virtual DbSet<TblSeller> TblSeller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("workstation id=CvDataBase.mssql.somee.com;packet size=4096;user id=AbdullahCV_SQLLogin_1;pwd=xdxv95yes8;data source=CvDataBase.mssql.somee.com;persist security info=False;initial catalog=CvDataBase;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("tbl_Item");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("Image_Url")
                    .HasMaxLength(220);

                entity.Property(e => e.ItemName)
                    .HasColumnName("Item_Name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblMsg>(entity =>
            {
                entity.ToTable("tbl_Msg");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblSeller>(entity =>
            {
                entity.HasKey(e => e.SellerId);

                entity.ToTable("tbl_Seller");

                entity.Property(e => e.SellerAddress)
                    .HasColumnName("Seller_Address")
                    .HasMaxLength(140);

                entity.Property(e => e.SellerEmail)
                    .HasColumnName("Seller_Email")
                    .HasMaxLength(30);

                entity.Property(e => e.SellerImageUrl)
                    .HasColumnName("Seller_ImageUrl")
                    .HasMaxLength(240);

                entity.Property(e => e.SellerName)
                    .HasColumnName("Seller_Name")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
