using Microsoft.EntityFrameworkCore;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class MundoBalloonContext : DbContext
{
    public MundoBalloonContext(DbContextOptions<MundoBalloonContext> options)
        : base(options)
    {
    }

    public DbSet<EventCartDetail> EventCartDetails { get; set; } = default!;
    public DbSet<Orders> Orders { get; set; } = default!;
    public DbSet<OrderProductsDetails> OrderProductDetails { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
    public DbSet<ProductVariant> ProductVariants { get; set; } = default!;
    public DbSet<ProductVariantMedium> ProductVariantMedia { get; set; } = default!;
    public DbSet<ProductVariantValue> ProductVariantValues { get; set; } = default!;
    public DbSet<ProductVariantReview> ProductVariantReviews { get; set; } = default!;
    public DbSet<UiRegistry> UiRegistries { get; set; } = null!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserCartProduct> UserCartProducts { get; set; } = default!;
    public DbSet<UserEvent> UserEvents { get; set; } = default!;
    public DbSet<UserAddresses> UserAddresses { get; set; } = default!;
    public DbSet<UserProfile> UserProfiles { get; set; } = default!;
    public DbSet<UserPaymentProfile> UserPaymentProfiles { get; set; } = default!;
    public DbSet<Variant> Variants { get; set; } = default!;
    public DbSet<VariantValue> VariantValues { get; set; } = default!;
    public DbSet<VariantsType> VariantsTypes { get; set; } = default!;
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

        modelBuilder.Entity<UserCartProduct>(entity =>
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

        modelBuilder.Entity<UserAddresses>(entity =>
        {
            entity.ToTable("user_addresses");

            entity.HasIndex(e => e.UserId, "fk_user_addreses_Users1_idx");

            entity.Property(e => e.UserAddressesId).HasColumnName("user_addresses_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.Address1)
                .HasColumnType("mediumtext")
                .HasColumnName("address1")
                .IsRequired();
            entity.Property(e => e.Address2)
                .HasColumnType("mediumtext")
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasColumnType("varchar(45)")
                .HasColumnName("city")
                .IsRequired();
            entity.Property(e => e.State)
                .HasColumnType("varchar(45)")
                .HasColumnName("state")
                .IsRequired();
            entity.Property(e => e.Country)
                .HasColumnType("varchar(45)")
                .HasColumnName("country")
                .IsRequired();
            entity.Property(e => e.Zipcode)
                .HasColumnType("varchar(45)")
                .HasColumnName("zipcode")
                .IsRequired();
            entity.Property(e => e.IsBilling)
                .HasColumnName("is_billing");
            entity.Property(e => e.IsShipping)
                .HasColumnName("is_shipping");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.HasOne(d => d.User)
                .WithMany(p => p.UserAdrresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_addreses_Users1");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.ToTable("user_profile");

            entity.HasIndex(e => e.UserId, "fk_user_profile_users1_idx");

            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.FirstName)
                .HasColumnType("varchar(45)")
                .HasColumnName("first_name")
                .IsRequired();
            entity.Property(e => e.LastName)
                .HasColumnType("varchar(45)")
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("int")
                .HasColumnName("phone_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.HasOne(d => d.User)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_profile_users1");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.ToTable("orders");
            entity.HasIndex(e => e.UserId, "fk_orders_user1_idx");
            entity.HasIndex(e => e.UserAddressesId, "fk_orders_user_addresses1_idx");
            entity.HasIndex(e => e.UserProfileId, "fk_orders_user_profile1_idx");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.HasKey(e => e.OrderId)
                .HasName("PRIMARY");

            entity.Property(e => e.UserId)
                .HasColumnType("varchar(45)")
                .HasColumnName("user_id");
            entity.Property(e => e.UserAddressesId)
                .HasColumnType("int")
                .HasColumnName("user_addresses_id");
            entity.Property(e => e.UserProfileId)
                .HasColumnType("int")
                .HasColumnName("user_profile_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_orders_users1");

            entity.HasOne(d => d.UserProfile)
                .WithMany(p => p.UserProfileOrder)
                .HasForeignKey(d => d.UserProfileId)
                .HasConstraintName("fk_orders_user_profile1");

            entity.HasOne(d => d.UserAddresses)
                .WithMany(p => p.OrdersUserAddresses)
                .HasForeignKey(d => d.UserAddressesId)
                .HasConstraintName("fk_orders_user_addresses1");
        });

        modelBuilder.Entity<OrderProductsDetails>(entity =>
        {
            entity.ToTable("order_products_details");
            entity.HasIndex(e => e.ProductVariantId, "fk_orders_product_variants1_idx");
            entity.HasIndex(e => e.OrderId, "fk_order_products_details_order_idx");

            entity.Property(e => e.OrderDetailsProductsId).HasColumnName("order_details_products_id");
            entity.HasKey(e => e.OrderDetailsProductsId)
                .HasName("PRIMARY");

            entity.Property(e => e.ProductVariantId)
                .HasColumnType("int")
                .HasColumnName("product_variant_id");
            entity.Property(e => e.OrderId)
                .HasColumnType("int")
                .HasColumnName("order_id");
            entity.Property(e => e.Amount)
                .HasColumnType("int")
                .HasColumnName("amount");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("price");
            entity.Property(e => e.OrderId)
                .HasColumnType("int")
                .HasColumnName("order_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.HasOne(d => d.ProductVariant)
                .WithMany(p => p.OrderProductsDetailsProductVariants)
                .HasPrincipalKey(p => p.ProductVariantId)
                .HasForeignKey(d => d.ProductVariantId)
                .HasConstraintName("fk_order_products_details_product_variant1");
            entity.HasOne(d => d.Order)
                .WithMany(p => p.OrdersOrderProductsDetails)
                .HasPrincipalKey(p => p.OrderId)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_order_products_details_orders1");
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

            entity.HasIndex(e => e.UiRegistryId, "variants_ui_registry_null_fk");

            entity.Property(e => e.VariantId).HasColumnName("variant_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("isDeleted")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.UiRegistryId).HasColumnName("ui_registry_id");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.Variant1)
                .HasMaxLength(45)
                .HasColumnName("variant");

            entity.Property(e => e.VariantTypeId)
                .HasColumnName("variant_type_id");

            entity.HasOne(d => d.UiRegistry)
                .WithMany(p => p.Variants)
                .HasForeignKey(d => d.UiRegistryId)
                .HasConstraintName("variants_ui_registry_null_fk");

            entity.HasOne(d => d.VariantsType).WithMany(p => p.Variants)
                .HasForeignKey(d => d.VariantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variants_variants_type_variant_type_id_fk");
        });

        modelBuilder.Entity<UiRegistry>(entity =>
        {
            entity.ToTable("ui_registry");

            entity.ToTable(t => t.HasComment("This is to tie some values to UI components to render them"));

            entity.HasIndex(e => e.ComponentId, "ui_registry_component_id_index");

            entity.Property(e => e.UiRegistryId).HasColumnName("ui_registry_id");

            entity.Property(e => e.ComponentId)
                .HasMaxLength(50)
                .HasColumnName("component_id");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.Property(e => e.Deprecated).HasColumnName("deprecated");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("isDeleted")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
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

        modelBuilder.Entity<VariantsType>(entity =>
        {
            entity.ToTable("variants_type");

            entity.HasKey(e => e.VariantTypeId).HasName("pk_variants_type");

            entity.Property(e => e.VariantTypeId).HasColumnName("variant_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnType("timestamp(6)")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnType("timestamp(6)")
                .HasColumnName("updated_at");
            entity.Property(e => e.VariantType)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("variant_type");
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
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Added:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
    }
}