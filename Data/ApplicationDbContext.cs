using Microsoft.EntityFrameworkCore;
using WebTestCoreEntity.Models;

namespace WebTestCoreEntity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<AssetType> AssetType { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssetType>().HasKey(a => a.Code);
        }
    }
}
