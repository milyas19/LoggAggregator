using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data
{
    internal class LoggAggregatorConfig : IEntityTypeConfiguration<LoggAggregatorContext>
    {
        public void Configure(EntityTypeBuilder<LoggAggregatorContext> builder)
        {
            builder.ToTable("LoggAggregator");
        }
    }
}