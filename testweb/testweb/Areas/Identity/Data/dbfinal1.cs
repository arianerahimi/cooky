using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testweb.Areas.Identity.Data;
using testweb.Models;

namespace testweb.Data;

public class dbfinal1 : IdentityDbContext<ApplicationUser>
{
    public dbfinal1(DbContextOptions<dbfinal1> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Brand> Brands { get; set; }
    //public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<purchaseCart> PurchaseCarts { get; set; }
    public DbSet<PurchaseCartItem> PurchaseCartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
