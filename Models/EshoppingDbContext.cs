using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace REPR_API.Models;

public partial class EshoppingDbContext : DbContext
{
    public EshoppingDbContext()
    {
    }

    public EshoppingDbContext(DbContextOptions<EshoppingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=EShoppingDB;Integrated Security=SSPI;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryUniqueId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductUniqueId);

            entity.HasIndex(e => e.CategoryUniqueId, "IX_Products_CategoryUniqueId");

            entity.HasOne(d => d.CategoryUnique).WithMany(p => p.Products).HasForeignKey(d => d.CategoryUniqueId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
