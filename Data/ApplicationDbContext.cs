using Microsoft.EntityFrameworkCore;
using HomeWork.Models;

namespace HomeWork.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=identityinfo.db");
            }
        }

        public DbSet<IdentityInfo> IdentityInfos { get; set; }
    }
}
