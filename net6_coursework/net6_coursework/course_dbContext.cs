using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace net6_coursework
{
    public partial class course_dbContext : DbContext
    {
        public course_dbContext()
        {
        }

        public course_dbContext(DbContextOptions<course_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=course_db;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.HasKey(e => e.AvailableId)
                    .HasName("availability_pkey");

                entity.ToTable("availability");

                entity.Property(e => e.AvailableId)
                    .HasColumnName("available_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_good_id");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shop_id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("goods");

                entity.Property(e => e.GoodId)
                    .HasColumnName("good_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("barcode");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_category");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("prices");

                entity.Property(e => e.PriceId)
                    .HasColumnName("price_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AvailableId).HasColumnName("available_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Price1)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.HasOne(d => d.Available)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.AvailableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_available_id");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shops");

                entity.Property(e => e.ShopId)
                    .HasColumnName("shop_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Rating)
                    .HasPrecision(10, 2)
                    .HasColumnName("rating");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
