using Microsoft.EntityFrameworkCore;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class MundoBalloonContext : DbContext
{
    public MundoBalloonContext(DbContextOptions<MundoBalloonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CountryCode> CountryCodes { get; set; }

    public virtual DbSet<EventCartDetail> EventCartDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<ProductVariantMedium> ProductVariantMedia { get; set; }

    public virtual DbSet<ProductVariantReview> ProductVariantReviews { get; set; }

    public virtual DbSet<ProductVariantValue> ProductVariantValues { get; set; }

    public virtual DbSet<UiRegistry> UiRegistries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<UserCart> UserCarts { get; set; }

    public virtual DbSet<UserEvent> UserEvents { get; set; }

    public virtual DbSet<UserPaymentProfile> UserPaymentProfiles { get; set; }

    public virtual DbSet<Variant> Variants { get; set; }

    public virtual DbSet<VariantValue> VariantValues { get; set; }

    public virtual DbSet<VariantsType> VariantsTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryCode>(entity =>
        {
            entity.HasKey(e => new { e.Fifa, e.Wmo }).HasName("pk_country_codes");

            entity.ToTable("country_codes", "mundob-dev");

            entity.HasIndex(e => e.Dial, "country_codes_Dial_index");

            entity.Property(e => e.Fifa)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("FIFA");
            entity.Property(e => e.Wmo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("WMO");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Dial)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.OfficialNameEn)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("official_name_en");
            entity.Property(e => e.OfficialNameEs)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("official_name_es");
            entity.Property(e => e.Supported).HasColumnName("supported");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EventCartDetail>(entity =>
        {
            entity.HasKey(e => e.EventCartDetailId).HasName("pk_event_cart_details");

            entity.ToTable("event_cart_details", "mundob-dev");

            entity.HasIndex(e => e.ProductVariantId, "fk_event_cart_details_product_variants2_idx");

            entity.Property(e => e.EventCartDetailId).HasColumnName("event_cart_detail_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserEventId).HasColumnName("user_event_id");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.EventCartDetails)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_event_cart_details_product_variants2");

            entity.HasOne(d => d.UserEvent).WithMany(p => p.EventCartDetails)
                .HasForeignKey(d => d.UserEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_event_cart_details_user_event_user_event_id_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("pk_product");

            entity.ToTable("products", "mundob-dev");

            entity.HasIndex(e => e.ProductCategoryId, "products_product_category_id_index");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("product_description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_ProductCategory1");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("pk_product_category");

            entity.ToTable("product_category", "mundob-dev");

            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProductCategoryDescription)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("product_category_description");
            entity.Property(e => e.ProductCategoryName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("product_category_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.ProductVariantId).HasName("pk_product_variants");

            entity.ToTable("product_variants", "mundob-dev");

            entity.HasIndex(e => e.ProductId, "fk_product_variants_products1_idx");

            entity.HasIndex(e => e.Sku, "sku_UNIQUE").IsUnique();

            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductVariantDescription)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("product_variant_description");
            entity.Property(e => e.ProductVariantName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("product_variant_name");
            entity.Property(e => e.Sku)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_variants_products1");
        });

        modelBuilder.Entity<ProductVariantMedium>(entity =>
        {
            entity.HasKey(e => e.ProductVariantMediaId).HasName("pk_product_variant_media");

            entity.ToTable("product_variant_media", "mundob-dev");

            entity.HasIndex(e => e.ProductVariantId, "fk_product_variant_media_product_variants1_idx");

            entity.Property(e => e.ProductVariantMediaId).HasColumnName("product_variant_media_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.MediaType)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("media_type");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");
            entity.Property(e => e.Quality)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("quality");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.ProductVariantMedia)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_variant_media_product_variants1");
        });

        modelBuilder.Entity<ProductVariantReview>(entity =>
        {
            entity.HasKey(e => e.ProductVariantReviewId).HasName("pk_product_variant_review");

            entity.ToTable("product_variant_review", "mundob-dev");

            entity.HasIndex(e => e.ProductVariantId, "fk_product_variants_idx");

            entity.HasIndex(e => e.UserId, "fk_users_idx");

            entity.Property(e => e.ProductVariantReviewId).HasColumnName("product_variant_review_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.ProductVariantReviews)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_variant_review_product_variant1");

            entity.HasOne(d => d.User).WithMany(p => p.ProductVariantReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_product_variant_review_user1");
        });

        modelBuilder.Entity<ProductVariantValue>(entity =>
        {
            entity.HasKey(e => new { e.ProductVariantId, e.VariantId, e.VariantValueId })
                .HasName("pk_product_variant_values");

            entity.ToTable("product_variant_values", "mundob-dev");

            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");
            entity.Property(e => e.VariantId).HasColumnName("variant_id");
            entity.Property(e => e.VariantValueId).HasColumnName("variant_value_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.ProductVariantValues)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variant_values_product_variants_product_variant_id_fk");

            entity.HasOne(d => d.Variant).WithMany(p => p.ProductVariantValues)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variant_values_variants_variant_id_fk");

            entity.HasOne(d => d.VariantValue).WithMany(p => p.ProductVariantValues)
                .HasForeignKey(d => d.VariantValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variant_values_variant_values_variant_value_id_fk");
        });

        modelBuilder.Entity<UiRegistry>(entity =>
        {
            entity.HasKey(e => e.UiRegistryId).HasName("pk_ui_registry");

            entity.ToTable("ui_registry", "mundob-dev");

            entity.HasIndex(e => e.ComponentId, "ui_registry_component_id_index");

            entity.Property(e => e.UiRegistryId).HasColumnName("ui_registry_id");
            entity.Property(e => e.ComponentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("component_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Deprecated).HasColumnName("deprecated");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_users");

            entity.ToTable("users", "mundob-dev");

            entity.HasIndex(e => e.UserId, "users_user_id_index");

            entity.Property(e => e.UserId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasKey(e => e.UserAddressesId).HasName("pk_user_addresses");

            entity.ToTable("user_addresses", "mundob-dev");

            entity.HasIndex(e => e.UserId, "fk_user_addresses_Users1_idx");

            entity.Property(e => e.UserAddressesId).HasColumnName("user_addresses_id");
            entity.Property(e => e.Address1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsBilling)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_billing");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.IsShipping).HasColumnName("is_shipping");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("zipcode");

            entity.HasOne(d => d.User).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_addresses_Users1");
        });

        modelBuilder.Entity<UserCart>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.Sku }).HasName("pk_user_cart");

            entity.ToTable("user_cart", "mundob-dev");

            entity.HasIndex(e => e.Sku, "fk_user_cart_product_variants1_idx");

            entity.HasIndex(e => e.ProductVariantId, "fk_user_cart_product_variants2_idx");

            entity.Property(e => e.UserId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.Sku)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.UserCartProductVariants)
                .HasForeignKey(d => d.ProductVariantId)
                .HasConstraintName("fk_user_cart_product_variants2");

            entity.HasOne(d => d.User).WithMany(p => p.UserCarts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_cart_Users1");
        });

        modelBuilder.Entity<UserEvent>(entity =>
        {
            entity.HasKey(e => e.UserEventId).HasName("pk_user_event");

            entity.ToTable("user_event", "mundob-dev");

            entity.HasIndex(e => e.UserId, "fk_user_event_Users1_idx");

            entity.Property(e => e.UserEventId).HasColumnName("user_event_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EventDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("event_date");
            entity.Property(e => e.EventDetails)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("event_details");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("event_name");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserEvents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_occasion_Users1");
        });

        modelBuilder.Entity<UserPaymentProfile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId).HasName("pk_user_payment_profile");

            entity.ToTable("user_payment_profile", "mundob-dev");

            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProcessorId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("processor_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserPaymentProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_payment_profile_users_id_fk");
        });

        modelBuilder.Entity<Variant>(entity =>
        {
            entity.HasKey(e => e.VariantId).HasName("pk_variants");

            entity.ToTable("variants", "mundob-dev");

            entity.Property(e => e.VariantId).HasColumnName("variant_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UiRegistryId).HasColumnName("ui_registry_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Variant1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("variant");
            entity.Property(e => e.VariantTypeId).HasColumnName("variant_type_id");

            entity.HasOne(d => d.UiRegistry).WithMany(p => p.Variants)
                .HasForeignKey(d => d.UiRegistryId)
                .HasConstraintName("variants_ui_registry_id_fk");

            entity.HasOne(d => d.VariantType).WithMany(p => p.Variants)
                .HasForeignKey(d => d.VariantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variants_variants_type_id_fk");
        });

        modelBuilder.Entity<VariantValue>(entity =>
        {
            entity.HasKey(e => e.VariantValueId).HasName("pk_variant_value");

            entity.ToTable("variant_values", "mundob-dev");

            entity.HasIndex(e => e.VariantId, "fk_variant_values_variants1_idx");

            entity.Property(e => e.VariantValueId).HasColumnName("variant_value_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VariantId).HasColumnName("variant_id");
            entity.Property(e => e.VariantValue1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("variant_value");

            entity.HasOne(d => d.Variant).WithMany(p => p.VariantValues)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_variant_values_variants1");
        });

        modelBuilder.Entity<VariantsType>(entity =>
        {
            entity.HasKey(e => e.VariantTypeId).HasName("pk_variants_type");

            entity.ToTable("variants_type", "mundob-dev");

            entity.Property(e => e.VariantTypeId).HasColumnName("variant_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VariantType)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("variant_type");
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