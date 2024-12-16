using Microsoft.EntityFrameworkCore;
using Pay.Domain.Moldes;
using Pay.Infra.Data.Configurations;

namespace Pay.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
