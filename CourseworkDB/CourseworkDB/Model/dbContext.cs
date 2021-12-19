using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace CourseworkDB
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<AvailabilityLog> AvailabilityLogs { get; set; }
        public virtual DbSet<CategoriesLog1> CategoriesLogs1 { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodsLog> GoodsLogs { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<PricesLog> PricesLogs { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopsLog> ShopsLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=course_db;Username=postgres;Password=1234");
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

                //entity.HasIndex(e => e.AvailableId, "availability_available_id_idx");

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

            modelBuilder.Entity<AvailabilityLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("availability_log");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AvailableId).HasColumnName("available_id").UseIdentityAlwaysColumn();

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");
            });

            modelBuilder.Entity<CategoriesLog1>(entity =>
            {
                entity.ToTable("categories_log");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
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

                //entity.HasIndex(e => e.GoodId, "goods_good_id_idx");

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

            modelBuilder.Entity<GoodsLog>(entity =>
            {

                entity.ToTable("goods_log");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("barcode");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.GoodId).HasColumnName("good_id").UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("prices");

                //entity.HasIndex(e => e.PriceId, "prices_price_id_idx");

                entity.Property(e => e.PriceId)
                    .HasColumnName("price_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AvailableId).HasColumnName("available_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Price1)
                    .HasColumnName("price");

                entity.HasOne(d => d.Available)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.AvailableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_available_id");
            });

            modelBuilder.Entity<PricesLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("prices_log");

                entity.Property(e => e.AvailableId).HasColumnName("available_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Price)
                    .HasColumnName("price");

                entity.Property(e => e.PriceId).HasColumnName("price_id").UseIdentityAlwaysColumn();
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shops");

                //entity.HasIndex(e => e.ShopId, "shops_shop_id_idx");

                entity.Property(e => e.ShopId)
                    .HasColumnName("shopid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating");
            });

            modelBuilder.Entity<ShopsLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shops_log");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating");

                entity.Property(e => e.ShopId).HasColumnName("shop_id").UseIdentityAlwaysColumn();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
