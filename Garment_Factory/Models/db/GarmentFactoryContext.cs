using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Garment_Factory.Models.db;

public partial class GarmentFactoryContext : DbContext
{
    public GarmentFactoryContext()
    {
    }

    public GarmentFactoryContext(DbContextOptions<GarmentFactoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessoriesProduct> AccessoriesProducts { get; set; }

    public virtual DbSet<AccessoriesStock> AccessoriesStocks { get; set; }

    public virtual DbSet<Accessory> Accessories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Compound> Compounds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductOrder> ProductOrders { get; set; }

    public virtual DbSet<Textile> Textiles { get; set; }

    public virtual DbSet<TextileStock> TextileStocks { get; set; }

    public virtual DbSet<TypeAccessory> TypeAccessories { get; set; }

    public virtual DbSet<TypePicture> TypePictures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=GarmentFactory;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessoriesProduct>(entity =>
        {
            entity.HasKey(e => new { e.IdAccessories, e.IdProduct }).HasName("PK__Accessor__77410CB6A349E9F2");

            entity.ToTable("Accessories_Product");

            entity.Property(e => e.IdAccessories)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_Accessories");
            entity.Property(e => e.IdProduct).HasColumnName("id_Product");
            entity.Property(e => e.Cord).IsUnicode(false);

            entity.HasOne(d => d.IdAccessoriesNavigation).WithMany(p => p.AccessoriesProducts)
                .HasForeignKey(d => d.IdAccessories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accessori__id_Ac__6D0D32F4");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.AccessoriesProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accessori__id_Pr__6C190EBB");
        });

        modelBuilder.Entity<AccessoriesStock>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdAccessories }).HasName("FK_Accessories_Stock_id");

            entity.ToTable("Accessories_Stock");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAccessories)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_Accessories");

            entity.HasOne(d => d.IdAccessoriesNavigation).WithMany(p => p.AccessoriesStocks)
                .HasForeignKey(d => d.IdAccessories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accessories_Stock");
        });

        modelBuilder.Entity<Accessory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accessor__3213E83F437A615E");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasMany(d => d.IdTypeAccessories).WithMany(p => p.IdAccessories)
                .UsingEntity<Dictionary<string, object>>(
                    "AccessoriesTypeAccessory",
                    r => r.HasOne<TypeAccessory>().WithMany()
                        .HasForeignKey("IdTypeAccessories")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accessori__id_Ty__693CA210"),
                    l => l.HasOne<Accessory>().WithMany()
                        .HasForeignKey("IdAccessories")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accessori__id_Ac__68487DD7"),
                    j =>
                    {
                        j.HasKey("IdAccessories", "IdTypeAccessories").HasName("PK__Accessor__C2B9959012180FE3");
                        j.ToTable("Accessories_TypeAccessories");
                        j.IndexerProperty<string>("IdAccessories")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("id_Accessories");
                        j.IndexerProperty<int>("IdTypeAccessories").HasColumnName("id_TypeAccessories");
                    });
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Color__3213E83F6EBBC71F");

            entity.ToTable("Color");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Compound>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Compound__3213E83F4B6F6C1A");

            entity.ToTable("Compound");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F20508FE5");

            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Customer)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Manager)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.OrderCustomerNavigations)
                .HasForeignKey(d => d.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__Customer__4E88ABD4");

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.OrderManagerNavigations)
                .HasForeignKey(d => d.Manager)
                .HasConstraintName("FK__Order__Manager__4F7CD00D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07DE74ACFE");

            entity.ToTable("Product");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<ProductOrder>(entity =>
        {
            entity.HasKey(e => new { e.IdProduct, e.IdOrder }).HasName("PK__Product___CE51356EA30D971F");

            entity.ToTable("Product_Order");

            entity.Property(e => e.IdProduct).HasColumnName("id_Product");
            entity.Property(e => e.IdOrder).HasColumnName("id_Order");
            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ProductOrders)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_O__id_Or__534D60F1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductOrders)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_O__id_Pr__52593CB8");
        });

        modelBuilder.Entity<Textile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Textile__3213E83F8243ABCC");

            entity.ToTable("Textile");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.TypePicture).HasColumnName("Type_Picture");

            entity.HasOne(d => d.TypePictureNavigation).WithMany(p => p.Textiles)
                .HasForeignKey(d => d.TypePicture)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Textile__Type_Pi__31EC6D26");

            entity.HasMany(d => d.IdColors).WithMany(p => p.IdTextiles)
                .UsingEntity<Dictionary<string, object>>(
                    "TextileColor",
                    r => r.HasOne<Color>().WithMany()
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Textile_C__id_Co__35BCFE0A"),
                    l => l.HasOne<Textile>().WithMany()
                        .HasForeignKey("IdTextile")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Textile_C__id_Te__34C8D9D1"),
                    j =>
                    {
                        j.HasKey("IdTextile", "IdColor").HasName("PK__Textile___C61DC1BA5A72D24A");
                        j.ToTable("Textile_Color");
                        j.IndexerProperty<int>("IdTextile").HasColumnName("id_Textile");
                        j.IndexerProperty<int>("IdColor").HasColumnName("id_Color");
                    });

            entity.HasMany(d => d.IdCompounds).WithMany(p => p.IdTextiles)
                .UsingEntity<Dictionary<string, object>>(
                    "TextileCompound",
                    r => r.HasOne<Compound>().WithMany()
                        .HasForeignKey("IdCompound")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Textile_C__id_Co__398D8EEE"),
                    l => l.HasOne<Textile>().WithMany()
                        .HasForeignKey("IdTextile")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Textile_C__id_Te__38996AB5"),
                    j =>
                    {
                        j.HasKey("IdTextile", "IdCompound").HasName("PK__Textile___3BB83F9B08EAA6F1");
                        j.ToTable("Textile_Compound");
                        j.IndexerProperty<int>("IdTextile").HasColumnName("id_Textile");
                        j.IndexerProperty<int>("IdCompound").HasColumnName("id_Compound");
                    });

            entity.HasMany(d => d.IdProducts).WithMany(p => p.IdTextiles)
                .UsingEntity<Dictionary<string, object>>(
                    "TextileProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Textile_P__id_Pr__403A8C7D"),
                    l => l.HasOne<Textile>().WithMany()
                        .HasForeignKey("IdTextile")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Textile_P__id_Te__3F466844"),
                    j =>
                    {
                        j.HasKey("IdTextile", "IdProduct").HasName("PK__Textile___E541904A4BCCCE91");
                        j.ToTable("Textile_Product");
                        j.IndexerProperty<int>("IdTextile").HasColumnName("id_Textile");
                        j.IndexerProperty<int>("IdProduct").HasColumnName("id_Product");
                    });
        });

        modelBuilder.Entity<TextileStock>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdTextile }).HasName("PK__Textile___D0EFD9B915C53626");

            entity.ToTable("Textile_Stock");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTextile).HasColumnName("id_Textile");

            entity.HasOne(d => d.IdTextileNavigation).WithMany(p => p.TextileStocks)
                .HasForeignKey(d => d.IdTextile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Textile_S__id_Te__3C69FB99");
        });

        modelBuilder.Entity<TypeAccessory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeAcce__3213E83F255BFE31");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<TypePicture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypePict__3213E83F720D895D");

            entity.ToTable("TypePicture");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Login).HasName("PK__Users__5E55825A8DCE2880");

            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
