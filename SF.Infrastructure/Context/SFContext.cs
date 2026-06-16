using Microsoft.EntityFrameworkCore;
using SF.Domain.Entity;

namespace SF.Infrastructure.Context
{
    public class SFContext : DbContext
    {
        public SFContext(DbContextOptions<SFContext> options):base(options)
        {}

        public SFContext()
        {}

        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        public DbSet<Domain.Entity.Supplier> Supplier { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Description).IsRequired();
                entity.Property(c => c.CreatedDate).IsRequired();
                entity.Property(c => c.Status).IsRequired();

                entity.HasMany(c => c.Products)
                    .WithOne(c => c.Category)
                    .HasPrincipalKey(c => c.Id)
                    .HasForeignKey(c => c.CategoryId);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.LastName).IsRequired();
                entity.Property(c => c.Email).IsRequired();
                entity.Property(c => c.PhoneNumber).IsRequired();
                entity.Property(c => c.CreatedDate).IsRequired();
                entity.Property(c => c.Status).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.UpdatedDate).IsRequired(false);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.Price).IsRequired();
                entity.Property(p => p.CreatedDated).IsRequired();
                entity.Property(p => p.UpdatedDate).IsRequired(false);
                entity.Property(p => p.Status).IsRequired();
                entity.Property(p => p.CategoryId).IsRequired();
                entity.Property(p => p.SupplierId).IsRequired();

                entity.HasMany(p => p.ProductStocks)
                    .WithOne(p => p.Product)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(p => p.ProductId);

                entity.HasOne(p => p.Category)
                    .WithMany(p => p.Products)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(p => p.CategoryId);

                entity.HasOne(p => p.Supplier)
                    .WithMany(p => p.Products)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(p => p.SupplierId);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.Name).IsRequired();
                entity.Property(w => w.Location).IsRequired();
                entity.Property(w => w.ManagerName).IsRequired();
                entity.Property(w => w.ContactPhone).IsRequired();
                entity.Property(w => w.CreatedDate).IsRequired();
                entity.Property(w => w.UpdatedDate).IsRequired(false);
                entity.Property(w => w.IsActive).IsRequired();
                

                entity.HasMany(w => w.ProductStocks)
                    .WithOne(w => w.Warehouse)
                    .HasPrincipalKey(w => w.Id)
                    .HasForeignKey(w => w.WarehouseId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}