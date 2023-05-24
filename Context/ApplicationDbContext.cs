using MAUIapi.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUIapi.Context
{
    // ApplicationDbContext.cs
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
