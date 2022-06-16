using LCWaikikiFinal.Domain.Configurations;
using LCWaikikiFinal.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LCWaikikiFinal.Infrastructure.Contexts
{
        public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
        {
                public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

                #region Entities

                public DbSet<Category> Categories { get; set; }
                public DbSet<Product> Products { get; set; }
                public DbSet<ProductDetail> ProductDetails { get; set; }
                public DbSet<Lifecycle> Lifecycles { get; set; }
                public DbSet<Brand> Brands { get; set; }
                public DbSet<Color> Colors { get; set; }
                public DbSet<Offer> Offers { get; set; }
                public DbSet<Size> Sizes { get; set; }

                #endregion

                #region SaveChangesAsync

                public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
                {
                        foreach (var entry in ChangeTracker.Entries<EntityBase>())
                        {
                                switch (entry.State)
                                {
                                        case EntityState.Added:
                                                entry.Entity.CreatedDate = DateTime.Now;

                                                break;
                                        case EntityState.Modified:
                                                entry.Entity.LastModifiedDate = DateTime.Now;
                                                break;
                                }
                        }
                        return base.SaveChangesAsync(cancellationToken);
                }

                #endregion

                #region OnModelCreating

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
                        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
                        modelBuilder.ApplyConfiguration(new ProductConfiguration());
                        modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
                        modelBuilder.ApplyConfiguration(new LifecycleConfiguration());
                        modelBuilder.ApplyConfiguration(new ColorConfiguration());
                        modelBuilder.ApplyConfiguration(new BrandConfiguration());
                        modelBuilder.ApplyConfiguration(new OfferConfiguration());
                        modelBuilder.ApplyConfiguration(new SizeConfiguration());

                        base.OnModelCreating(modelBuilder);
                }

                #endregion
        }
}
