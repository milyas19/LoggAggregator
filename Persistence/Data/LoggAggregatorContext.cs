using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class LoggAggregatorContext : DbContext
    {
        public DbSet<LoggAggregator> LoggAggregators { get; set; }
        public LoggAggregatorContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LoggAggregatorConfig());
        }
    }
}
