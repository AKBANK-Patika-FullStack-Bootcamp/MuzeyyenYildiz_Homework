
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFLibCore
{
    public class WineContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public WineContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("UserDBEntities"));
            options.UseSqlServer("Data Source = localhost; Database = WineryDataDB; integrated security = True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>().ToTable("Wine");
            modelBuilder.Entity<Detail>().ToTable("Detail");
            modelBuilder.Entity<APIAuthority>().ToTable("APIAuthority");
        }
        public DbSet<Wine> Wine { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<APIAuthority> APIAuthority { get; set; }
    }
}
