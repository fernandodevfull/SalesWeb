using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

public class SalesWebMVCContext(DbContextOptions<SalesWebMVCContext> options) : DbContext(options)
{
    public DbSet<SalesWebMVC.Models.Department> Department { get; set; } = default!;

    public DbSet<Seller> Sellers { get; set; }
    public DbSet<SalesRecord> SalesRecords { get; set; }

}
