using Microsoft.EntityFrameworkCore;
using Web_Api_EF_Core.Models;

namespace Web_Api_EF_Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
