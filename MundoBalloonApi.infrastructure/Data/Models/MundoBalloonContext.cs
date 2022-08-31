using Microsoft.EntityFrameworkCore;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class MundoBalloonContext : DbContext
{
    public MundoBalloonContext(DbContextOptions<MundoBalloonContext> options)
        : base(options)
    {
    }

    public DbSet<EventCartDetail> EventCartDetails { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
    public DbSet<ProductVariant> ProductVariants { get; set; } = default!;
    public DbSet<ProductVariantMedium> ProductVariantMedia { get; set; } = default!;
    public DbSet<ProductVariantValue> ProductVariantValues { get; set; } = default!;
    public DbSet<ProductVariantReview> ProductVariantReviews { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserCart> UserCarts { get; set; } = default!;
    public DbSet<UserEvent> UserEvents { get; set; } = default!;
    public DbSet<UserPaymentProfile> UserPaymentProfiles { get; set; } = default!;
    public DbSet<Variant> Variants { get; set; } = default!;
    public DbSet<VariantValue> VariantValues { get; set; } = default!;
    public DbSet<CountryCode> CountryCodes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventCartDetail>(entity =>
        {
            entity.HasKey(e => e.EventCartDetailId)
                .HasName("PRIMARY");

            entity.ToTable("event_cart_details");

            entity.HasIndex(e => e.UserEventId, "event_cart_details_user_event_user_event_id_fk");

            entity.HasIndex(e => e.ProductVariantId, "fk_event_cart_details_product_variants2");

            entity.Property(e => e.EventCartDetailId).HasColumnName("event_cart_detail_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.ProductVariantId)
                .HasColumnName("product_variant_id");

            entity.Property(d => d.UserEventId)
                .HasColumnName("user_event_id");

            entity.Property(e => e.Quantity)
                .HasPrecision(10, 2)
                .HasColumnName("quantity");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.HasOne(d => d.UserEvent)
                .WithMany(p => p.EventCartDetails)
                .HasForeignKey(d => d.EventCartDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_cart_details_user_event_user_event_id_fk");

            entity.HasOne(d => d.ProductVariant)
                .WithMany(p => p.EventCartDetailProductVariants)
                .HasPrincipalKey(p => p.ProductVariantId)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_occasion_cart_details_product_variants2");
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
                .HasColumnName("product_description");

            entity.Property(e => e.ProductName)
                .HasColumnType("varchar(45)")
                .HasColumnName("product_name");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

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
                .HasColumnName("product_category_description");

            entity.Property(e => e.ProductCategoryName)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("product_category_name");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => new { e.ProductVariantId, e.Sku })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("product_variants");

            entity.HasIndex(e => e.ProductId, "fk_product_variants_products1_idx");

            entity.HasIndex(e => e.ProductVariantId, "product_variant_id_UNIQ_iE")
                .IsUnique();

            entity.HasIndex(e => e.Sku, "sku_UNIQUE")
                .IsUnique();

            entity.Property(e => e.ProductVariantId)
                .ValueGeneratedOnAdd()
                .HasColumnName("product_variant_id");

            entity.Property(e => e.Sku)
                .HasColumnType("varchar(45)")
                .HasColumnName("sku");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.ProductVariantDescription)
                .HasColumnType("varchar(45)")
                .HasColumnName("product_variant_description");

            entity.Property(e => e.ProductVariantName)
                .HasColumnType("varchar(45)")
                .HasColumnName("product_variant_name");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_variants_products1");
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
                .HasColumnName("media_type");

            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

            entity.Property(e => e.Quality)
                .HasColumnType("varchar(45)")
                .HasColumnName("quality");

            entity.Property(e => e.Name)
                .HasColumnType("varchar(45)")
                .HasColumnName("name");

            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.Property(e => e.Url)
                .IsRequired()
                .HasColumnType("mediumtext")
                .HasColumnName("url");

            entity.HasOne(d => d.ProductVariant)
                .WithMany(p => p.ProductVariantMedia)
                .HasPrincipalKey(p => p.ProductVariantId)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_variant_media_product_variants1");
        });

        modelBuilder.Entity<ProductVariantReview>(entity =>
        {
            entity.HasKey(e => e.ProductVariantReviewId)
                .HasName("PRIMARY");

            entity.ToTable("product_variant_review");

            entity.HasIndex(e => e.ProductVariantId, "fk_product_variants_idx");

            entity.HasIndex(e => e.UserId, "fk_users_idx");

            entity.Property(e => e.ProductVariantReviewId).HasColumnName("product_variant_review_id");
            
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.Rating)
                .IsRequired()
                .HasColumnType("smallint")
                .HasColumnName("rating");

            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

            entity.Property(e => e.Comments)
                .HasColumnType("text")
                .HasColumnName("comments");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.HasOne(d => d.ProductVariant)
                .WithMany(p => p.ProductVariantReviews)
                .HasPrincipalKey(p => p.ProductVariantId)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_variant_review_product_variant1");

            entity.HasOne(d => d.User)
                .WithMany(p => p.ProductVariantReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_product_variant_review_user1");
        });

        modelBuilder.Entity<ProductVariantValue>(entity =>
        {
            entity.HasKey(e => new { e.ProductVariantId, e.VariantId, e.VariantValueId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("product_variant_values");

            entity.HasIndex(e => e.VariantValueId, "product_variant_values_variant_values_variant_value_id_fk");

            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

            entity.Property(e => e.VariantId).HasColumnName("variant_id");

            entity.Property(e => e.VariantValueId).HasColumnName("variant_value_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("isDeleted")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.ProductVariant)
                .WithMany(p => p.ProductVariantValues)
                .HasPrincipalKey(p => p.ProductVariantId)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variant_values_product_variants_product_variant_id_fk");

            entity.HasOne(d => d.Variant)
                .WithMany(p => p.ProductVariantValues)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variant_values_variants_variant_id_fk");

            entity.HasOne(d => d.VariantValue)
                .WithMany(p => p.ProductVariantValues)
                .HasForeignKey(d => d.VariantValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variant_values_variant_values_variant_value_id_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasColumnType("varchar(45)")
                .HasColumnName("user_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
        });

        modelBuilder.Entity<UserCart>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.Sku })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("user_cart");

            entity.HasIndex(e => e.Sku, "fk_user_cart_product_variants1_idx");

            entity.HasIndex(e => e.ProductVariantId, "fk_user_cart_product_variants2_idx");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.Sku)
                .HasColumnType("varchar(45)")
                .HasColumnName("sku");

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

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

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

        modelBuilder.Entity<UserEvent>(entity =>
        {
            entity.ToTable("user_event");

            entity.HasIndex(e => e.UserId, "fk_user_event_Users1_idx");

            entity.Property(e => e.UserEventId).HasColumnName("user_event_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.EventDate)
                .HasColumnType("timestamp(6)")
                .HasColumnName("event_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.EventDetails)
                .HasColumnType("mediumtext")
                .HasColumnName("event_details");

            entity.Property(e => e.EventName)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("event_name");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserEvents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_event_Users1");
        });

        modelBuilder.Entity<UserPaymentProfile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId)
                .HasName("PRIMARY");

            entity.ToTable("user_payment_profile");

            entity.HasIndex(e => e.UserId, "user_id_UNIQUE")
                .IsUnique();

            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.ProcessorId)
                .HasColumnType("varchar(45)")
                .HasColumnName("processor_id");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserPaymentProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_payment_profile_users_id_fk");
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

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.Property(e => e.Variant1)
                .HasColumnType("varchar(45)")
                .HasColumnName("variant");

            entity.Property(e => e.VariantType)
                .HasColumnType("varchar(45)")
                .HasColumnName("variant_type");
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

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.Property(e => e.VariantId).HasColumnName("variant_id");

            entity.Property(e => e.VariantValue1)
                .HasColumnType("varchar(45)")
                .HasColumnName("variant_value");

            entity.HasOne(d => d.Variant)
                .WithMany(p => p.VariantValues)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_variant_values_variants1");
        });

        modelBuilder.Entity<CountryCode>(entity =>
        {
            entity.HasKey(e => new { e.Fifa, e.Wmo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("country_codes");

            entity.HasIndex(e => e.Dial, "country_codes_Dial_index");

            entity.Property(e => e.Fifa)
                .HasMaxLength(3)
                .HasColumnName("FIFA");

            entity.Property(e => e.Wmo)
                .HasMaxLength(3)
                .HasColumnName("WMO");

            entity.Property(e => e.Capital).HasColumnType("text");

            entity.Property(e => e.Continent).HasMaxLength(2);

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.Dial).HasMaxLength(5);

            entity.Property(e => e.Ds)
                .HasMaxLength(3)
                .HasColumnName("DS");

            entity.Property(e => e.GeoNameId).HasColumnName("Geoname ID");

            entity.Property(e => e.Ioc)
                .HasMaxLength(3)
                .HasColumnName("IOC");

            entity.Property(e => e.Itu)
                .HasMaxLength(3)
                .HasColumnName("ITU");

            entity.Property(e => e.Languages).HasColumnType("text");

            entity.Property(e => e.OfficialNameEn)
                .HasColumnType("text")
                .HasColumnName("official_name_en");

            entity.Property(e => e.OfficialNameEs)
                .HasColumnType("text")
                .HasColumnName("official_name_es");

            entity.Property(e => e.Supported)
                .HasColumnName("supported")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
        });

        modelBuilder.ApplyGlobalFilters<ISoftDelete>(e => e.IsDeleted == false);
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
        foreach (var entry in entries)
            if (entry.Entity is BaseEntity trackable)
                switch (entry.State)
                {
                    case EntityState.Modified:
                        var utcNow = DateTime.UtcNow;
                        trackable.UpdatedAt = utcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        trackable.IsDeleted = true;
                        break;
                }
    }
}