using Microsoft.EntityFrameworkCore;

namespace ExamenMarket.Models
{
    public class MarketContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {

        }
    }
}
