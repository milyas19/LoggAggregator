using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
