using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Model;

public partial class IsrpoContext : DbContext
{
    public IsrpoContext()
    {
    }

    public IsrpoContext(DbContextOptions<IsrpoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); Database=ISRPO;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Idcontract);

            entity.Property(e => e.Idcontract)
                .ValueGeneratedNever()
                .HasColumnName("IDContract");
            entity.Property(e => e.Idcustomers).HasColumnName("IDCustomers");
            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            entity.Property(e => e.Idsupplier).HasColumnName("IDSupplier");

            entity.HasOne(d => d.IdcustomersNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Idcustomers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Customers");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Products");

            entity.HasOne(d => d.IdsupplierNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Idsupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Suppliers");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Idcustomer);

            entity.Property(e => e.Idcustomer)
                .ValueGeneratedNever()
                .HasColumnName("IDCustomer");
            entity.Property(e => e.ContactInfo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Idemployee);

            entity.Property(e => e.Idemployee)
                .ValueGeneratedNever()
                .HasColumnName("IDEmployee");
            entity.Property(e => e.ContactInfo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Post).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct);

            entity.Property(e => e.Idproduct)
                .ValueGeneratedNever()
                .HasColumnName("IDProduct");
            entity.Property(e => e.Availability).HasMaxLength(50);
            entity.Property(e => e.Idemployees).HasColumnName("IDEmployees");
            entity.Property(e => e.Idtype).HasColumnName("IDType");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Сost).HasMaxLength(50);

            entity.HasOne(d => d.IdemployeesNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idemployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Employees");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Idsupplier).HasName("PK_Supplier");

            entity.Property(e => e.Idsupplier)
                .ValueGeneratedNever()
                .HasColumnName("IDSupplier");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ContactInfo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Idtype).HasName("PK_Type");

            entity.Property(e => e.Idtype)
                .ValueGeneratedNever()
                .HasColumnName("IDType");
            entity.Property(e => e.Info).HasMaxLength(50);
            entity.Property(e => e.NameType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
