using MarsAnalyzer.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace MarsAnalyzer.Data
{
    public class NasaContext : DbContext
    {
        public DbSet<PixelCondition> MapPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:nasa.database.windows.net,1433;Initial Catalog=nasa-space-app;Persist Security Info=False;User ID=yaebysobak;Password=Bongzilla123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}