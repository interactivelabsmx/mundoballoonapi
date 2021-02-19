using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class MundoBalloonContext : DbContext
    {
        public MundoBalloonContext(DbContextOptions<MundoBalloonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = default!;
        public virtual DbSet<OcassionCartDetail> OcassionCartDetails { get; set; } = default!;
        public virtual DbSet<OccasionCart> OccasionCarts { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = default!;
        public virtual DbSet<ProductVariant> ProductVariants { get; set; } = default!;
        public virtual DbSet<ProductVariantMedium> ProductVariantMedia { get; set; } = default!;
        public virtual DbSet<Session> Sessions { get; set; } = default!;
        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<UserAddrese> UserAddreses { get; set; } = default!;
        public virtual DbSet<UserCart> UserCarts { get; set; } = default!;
        public virtual DbSet<UserOccasion> UserOccasions { get; set; } = default!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = default!;
        public virtual DbSet<Variant> Variants { get; set; } = default!;
        public virtual DbSet<VariantValue> VariantValues { get; set; } = default!;
        public virtual DbSet<VerificationRequest> VerificationRequests { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.CompoundId, "compound_id")
                    .IsUnique();

                entity.HasIndex(e => e.ProviderAccountId, "provider_account_id");

                entity.HasIndex(e => e.ProviderId, "provider_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessToken)
                    .HasColumnType("text")
                    .HasColumnName("access_token")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AccessTokenExpires)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("access_token_expires");

                entity.Property(e => e.CompoundId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("compound_id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.ProviderAccountId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("provider_account_id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProviderId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("provider_id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProviderType)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("provider_type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.RefreshToken)
                    .HasColumnType("text")
                    .HasColumnName("refresh_token")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<OcassionCartDetail>(entity =>
            {
                entity.HasKey(e => new {e.OccasionCartId, e.Sku})
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] {0, 0});

                entity.ToTable("ocassion_cart_details");

                entity.HasIndex(e => e.Sku, "fk_ocassion_cart_details_product_variants1_idx");

                entity.HasIndex(e => e.ProductVariantId, "fk_ocassion_cart_details_product_variants2_idx");

                entity.Property(e => e.OccasionCartId).HasColumnName("occasion_cart_id");

                entity.Property(e => e.Sku)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("sku")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Label)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("label")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

                entity.Property(e => e.Quantity)
                    .HasPrecision(10, 2)
                    .HasColumnName("quantity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(d => d.OccasionCart)
                    .WithMany(p => p.OcassionCartDetails)
                    .HasForeignKey(d => d.OccasionCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocassion_cart_details_occasion_cart1");

                entity.HasOne(d => d.ProductVariant)
                    .WithMany(p => p.OcassionCartDetailProductVariants)
                    .HasPrincipalKey(p => p.ProductVariantId)
                    .HasForeignKey(d => d.ProductVariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocassion_cart_details_product_variants2");

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany(p => p.OcassionCartDetailSkuNavigations)
                    .HasPrincipalKey(p => p.Sku)
                    .HasForeignKey(d => d.Sku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocassion_cart_details_product_variants1");
            });

            modelBuilder.Entity<OccasionCart>(entity =>
            {
                entity.ToTable("occasion_cart");

                entity.HasIndex(e => e.UserOccasionId, "fk_occasion_cart_user_occasion1_idx");

                entity.Property(e => e.OccasionCartId).HasColumnName("occasion_cart_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.DropOffStage)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("drop_off_stage")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OccasionCartDescription)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("occasion_cart_description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UserOccasionId).HasColumnName("user_occasion_id");

                entity.HasOne(d => d.UserOccasion)
                    .WithMany(p => p.OccasionCarts)
                    .HasForeignKey(d => d.UserOccasionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_occasion_cart_user_occasion1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.ProductCategoryId, "fk_products_ProductCategory1_idx");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductDescription)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("product_description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductName)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("product_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products_ProductCategory1");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.ProductCategoryDescription)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("product_category_description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductCategoryName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("product_category_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.HasKey(e => new { e.ProductVariantId, e.Sku })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("product_variants");

                entity.HasIndex(e => e.ProductId, "fk_product_variants_products1_idx");

                entity.HasIndex(e => e.VariantValueId, "fk_product_variants_variant_values1_idx");

                entity.HasIndex(e => e.ProductVariantId, "product_variant_id_UNIQ_iE")
                    .IsUnique();

                entity.HasIndex(e => e.Sku, "sku_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ProductVariantId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("product_variant_id");

                entity.Property(e => e.Sku)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("sku")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CompareAtPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("compare_at_price");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.IsBundle).HasColumnName("is_bundle");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductVariantDescription)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("product_variant_description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductVariantName)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("product_variant_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StoreOnly).HasColumnName("store_only");

                entity.Property(e => e.Taxable).HasColumnName("taxable");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.VariantValueId).HasColumnName("variant_value_id");

                entity.Property(e => e.Weight)
                    .HasPrecision(10, 2)
                    .HasColumnName("weight");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_variants_products1");

                entity.HasOne(d => d.VariantValue)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.VariantValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_variants_variant_values1");
            });

            modelBuilder.Entity<ProductVariantMedium>(entity =>
            {
                entity.HasKey(e => e.ProductVariantMediaId)
                    .HasName("PRIMARY");

                entity.ToTable("product_variant_media");

                entity.HasIndex(e => e.ProductVariantId, "fk_product_variant_media_product_variants1_idx");

                entity.Property(e => e.ProductVariantMediaId).HasColumnName("product_variant_media_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.MediaType)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("media_type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

                entity.Property(e => e.Quality)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("quality")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("url")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.ProductVariant)
                    .WithMany(p => p.ProductVariantMedia)
                    .HasPrincipalKey(p => p.ProductVariantId)
                    .HasForeignKey(d => d.ProductVariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_variant_media_product_variants1");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("sessions");

                entity.HasIndex(e => e.AccessToken, "access_token")
                    .IsUnique();

                entity.HasIndex(e => e.SessionToken, "session_token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("access_token")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Expires)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("expires");

                entity.Property(e => e.SessionToken)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("session_token")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.EmailVerified)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("email_verified");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("image")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            });

            modelBuilder.Entity<UserAddrese>(entity =>
            {
                entity.HasKey(e => e.UserAddresesId)
                    .HasName("PRIMARY");

                entity.ToTable("user_addreses");

                entity.HasIndex(e => e.UserId, "fk_user_addreses_Users1_idx");

                entity.Property(e => e.UserAddresesId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_addreses_id");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("address1")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Address2)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("address2")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("city")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("country")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.IsBilling)
                    .HasColumnName("is_billing")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsShipping).HasColumnName("is_shipping");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("state")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("zipcode")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddreses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_user_addreses_Users1");
            });

            modelBuilder.Entity<UserCart>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.Sku})
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] {0, 0});

                entity.ToTable("user_cart");

                entity.HasIndex(e => e.Sku, "fk_user_cart_product_variants1_idx");

                entity.HasIndex(e => e.ProductVariantId, "fk_user_cart_product_variants2_idx");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Sku)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("sku")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

                entity.Property(e => e.Quantity)
                    .HasPrecision(10, 2)
                    .HasColumnName("quantity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(d => d.ProductVariant)
                    .WithMany(p => p.UserCartProductVariants)
                    .HasPrincipalKey(p => p.ProductVariantId)
                    .HasForeignKey(d => d.ProductVariantId)
                    .HasConstraintName("fk_user_cart_product_variants2");

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany(p => p.UserCartSkuNavigations)
                    .HasPrincipalKey(p => p.Sku)
                    .HasForeignKey(d => d.Sku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_cart_product_variants1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_cart_Users1");
            });

            modelBuilder.Entity<UserOccasion>(entity =>
            {
                entity.ToTable("user_occasion");

                entity.HasIndex(e => e.UserId, "fk_user_occasion_Users1_idx");

                entity.Property(e => e.UserOccasionId).HasColumnName("user_occasion_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.OccasionDate)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("occasion_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.OccasionDetails)
                    .HasColumnType("mediumtext")
                    .HasColumnName("occasion_details")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OccasionName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("occasion_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOccasions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_user_occasion_Users1");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserProfileId)
                    .HasName("PRIMARY");

                entity.ToTable("user_profile");

                entity.HasIndex(e => e.UserId, "user_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Picture)
                    .HasColumnType("mediumtext")
                    .HasColumnName("picture")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProcessorId)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("processor_id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .HasConstraintName("fk_user_profile_Users1");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.ToTable("variants");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Variant1)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("variant")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.VariantType)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("variant_type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<VariantValue>(entity =>
            {
                entity.ToTable("variant_values");

                entity.HasIndex(e => e.VariantId, "fk_variant_values_variants1_idx");

                entity.Property(e => e.VariantValueId).HasColumnName("variant_value_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.Property(e => e.VariantValue1)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("variant_value")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.VariantValues)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_variant_values_variants1");
            });

            modelBuilder.Entity<VerificationRequest>(entity =>
            {
                entity.ToTable("verification_requests");

                entity.HasIndex(e => e.Token, "token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Expires)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("expires");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("identifier")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("token")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            });

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default
        )
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedAt = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("created_at").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedAt = utcNow;
                            trackable.UpdatedAt = utcNow;
                            break;
                    }
        }
    }
}