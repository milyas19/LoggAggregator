using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data
{
    public class LoggAggregatorConfig : IEntityTypeConfiguration<LoggAggregator>
    {
        public void Configure(EntityTypeBuilder<LoggAggregator> builder)
        {
            builder.ToTable("LoggAggregator");
        }
    }
}