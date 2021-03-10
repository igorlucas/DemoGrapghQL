using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
