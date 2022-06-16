using Microsoft.EntityFrameworkCore;
using Task1.Entities;

namespace Task1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            base.OnConfiguring( optionsBuilder );
            //this connection string should be read from configuration file
            optionsBuilder.UseSqlServer( @"Data Source=.;Initial Catalog=AppDb;user id=sa;password=123" );

        }
        public DbSet<TargetWarmBuyers> TargetWarmBuyerss { get; set; }
    }
}
