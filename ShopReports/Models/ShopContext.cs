using Microsoft.EntityFrameworkCore;

namespace ShopReports.Models;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductTitle> Titles { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Supermarket> Supermarkets { get; set; }

    public DbSet<SupermarketLocation> SupermarketLocations { get; set; }

    public DbSet<Person> Persons { get; set; }

    public DbSet<PersonContact> PersonContacts { get; set; }

    public DbSet<ContactType> ContactTypes { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category
        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Titles)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId);

        // City
        modelBuilder.Entity<City>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<City>()
            .HasMany(c => c.Locations)
            .WithOne(l => l.City)
            .HasForeignKey(l => l.CityId);

        // ContactType
        modelBuilder.Entity<ContactType>()
            .HasKey(ct => ct.Id);

        modelBuilder.Entity<ContactType>()
            .HasMany(ct => ct.Contacts)
            .WithOne(c => c.Type)
            .HasForeignKey(c => c.ContactTypeId);

        // Customer
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Person)
            .WithOne(p => p.Customer)
            .HasForeignKey<Customer>(c => c.Id);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        // Location
        modelBuilder.Entity<Location>()
            .HasKey(l => l.Id);

        modelBuilder.Entity<Location>()
            .HasMany(l => l.Supermarkets)
            .WithOne(s => s.Location)
            .HasForeignKey(s => s.LocationId);

        // Manufacturer
        modelBuilder.Entity<Manufacturer>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<Manufacturer>()
            .HasMany(m => m.Products)
            .WithOne(p => p.Manufacturer)
            .HasForeignKey(p => p.ManufacturerId);

        // Order
        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Details)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.SupermarketLocation)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.SupermarketLocationId);

        // OrderDetail
        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => od.Id);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);

        // Person
        modelBuilder.Entity<Person>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Contacts)
            .WithOne(c => c.Person)
            .HasForeignKey(c => c.PersonId);

        // PersonContact
        modelBuilder.Entity<PersonContact>()
            .HasKey(pc => pc.Id);

        // Product
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Title)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.TitleId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Supplier)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SupplierId);

        // ProductTitle
        modelBuilder.Entity<ProductTitle>()
            .HasKey(pt => pt.Id);

        // Supermarket
        modelBuilder.Entity<Supermarket>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Supermarket>()
            .HasMany(s => s.Locations)
            .WithOne(sl => sl.Supermarket)
            .HasForeignKey(sl => sl.SupermarketId);

        // SupermarketLocation
        modelBuilder.Entity<SupermarketLocation>()
            .HasKey(sl => sl.Id);

        // Supplier
        modelBuilder.Entity<Supplier>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Supplier>()
            .HasMany(s => s.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);
    }
}
