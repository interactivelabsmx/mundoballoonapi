using Microsoft.EntityFrameworkCore;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class MundoBalloonContext : DbContext
{
    public MundoBalloonContext(DbContextOptions<MundoBalloonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OcassionCartDetail> OcassionCartDetails { get; set; } = default!;
    public virtual DbSet<OccasionCart> OccasionCarts { get; set; } = default!;
    public virtual DbSet<Product> Products { get; set; } = default!;
    public virtual DbSet<ProductCategory> ProductCategories { get; set; } = default!;
    public virtual DbSet<ProductVariant> ProductVariants { get; set; } = default!;
    public virtual DbSet<ProductVariantMedium> ProductVariantMedia { get; set; } = default!;
    public virtual DbSet<User> Users { get; set; } = default!;
    public virtual DbSet<UserAddresses> UserAddressess { get; set; } = default!;
    public virtual DbSet<UserCart> UserCarts { get; set; } = default!;
    public virtual DbSet<UserOccasion> UserOccasions { get; set; } = default!;
    public virtual DbSet<UserPaymentProfile> UserPaymentProfiles { get; set; } = default!;
    public virtual DbSet<Variant> Variants { get; set; } = default!;
    public virtual DbSet<VariantValue> VariantValues { get; set; } = default!;
    public virtual DbSet<CountryCode> CountryCodes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OcassionCartDetail>(entity =>
        {
            entity.HasKey(e => new { e.OccasionCartId, e.Sku })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("ocassion_cart_details");

            entity.HasIndex(e => e.Sku, "fk_ocassion_cart_details_product_variants1_idx");

            entity.HasIndex(e => e.ProductVariantId, "fk_ocassion_cart_details_product_variants2_idx");

            entity.Property(e => e.OccasionCartId).HasColumnName("occasion_cart_id");

            entity.Property(e => e.Sku)
                .HasColumnType("varchar(45)")
                .HasColumnName("sku");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.Label)
                .HasColumnType("varchar(45)")
                .HasColumnName("label");

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
                .HasColumnName("drop_off_stage");

            entity.Property(e => e.OccasionCartDescription)
                .IsRequired()
                .HasColumnType("mediumtext")
                .HasColumnName("occasion_cart_description");

            entity.Property(e => e.Title)
                .HasColumnType("varchar(45)")
                .HasColumnName("title");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

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

            entity.Property(e => e.VariantValueId).HasColumnName("variant_value_id");

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
                .HasColumnName("media_type");

            entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

            entity.Property(e => e.Quality)
                .HasColumnType("varchar(45)")
                .HasColumnName("quality");

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

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.UserId, "userId_UNIQUE")
                .IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.UserId)
                .HasColumnType("varchar(45)")
                .HasColumnName("userId");

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

        modelBuilder.Entity<UserAddresses>(entity =>
        {
            entity.HasKey(e => e.UserAddressesId)
                .HasName("PRIMARY");

            entity.ToTable("user_addresses");

            entity.HasIndex(e => e.UserId, "fk_user_addreses_Users1_idx");

            entity.Property(e => e.UserAddressesId)
                .ValueGeneratedNever()
                .HasColumnName("user_addresses_id");

            entity.Property(e => e.Address1)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("address1");

            entity.Property(e => e.Address2)
                .HasColumnType("varchar(45)")
                .HasColumnName("address2");

            entity.Property(e => e.City)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("city");

            entity.Property(e => e.Country)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("country");

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
                .HasColumnName("state");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.Zipcode)
                .IsRequired()
                .HasColumnType("varchar(45)")
                .HasColumnName("zipcode");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserAddressess)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_addreses_Users1");
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
                .HasColumnName("occasion_details");

            entity.Property(e => e.OccasionName)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("occasion_name");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserOccasions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_occasion_Users1");
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

            entity.Property(e => e.GeonameId).HasColumnName("Geoname ID");

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