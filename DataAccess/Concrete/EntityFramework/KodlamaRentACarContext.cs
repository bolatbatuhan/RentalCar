using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class KodlamaRentACarContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database =Kodlama_io_RentACar; Trusted_Connection = true ");
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Rentals> Rentals { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Customers> Customers { get; set; }

}
