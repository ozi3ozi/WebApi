using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;

    public IQueryable<Product> OrderedProducts => Products.OrderBy(p => p.Prix);

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        //Contrainte pour que la propriete Nom soit unique
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Nom)
            .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Nom = "Chaise", Prix = 199.99},
            new Product { Id = 2, Nom = "Table", Prix = 299.99},
            new Product { Id = 3, Nom = "Lampe", Prix = 19.99},
            new Product { Id = 4, Nom = "Tapis", Prix = 99.99}
        );
    }
}