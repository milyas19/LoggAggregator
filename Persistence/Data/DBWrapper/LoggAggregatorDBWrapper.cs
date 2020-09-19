using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Data.DBWrapper
{
    public class LoggAggregatorDBWrapper : IDBWrapper<LoggAggregator>
    {
        private readonly LoggAggregatorContext _context;

        public LoggAggregatorDBWrapper(LoggAggregatorContext context)
        {
            _context = context;
        }

        public async Task<LoggAggregator> Add(LoggAggregator log)
        {
            _context.Add(log);
            await _context.SaveChangesAsync();

            return log;
        }

        public async Task<List<LoggAggregator>> GetList()
        {
            return await _context.LoggAggregators.AsNoTracking().ToListAsync();
        }

        public async Task<LoggAggregator> GetSingle(int id)
        {
            return await _context.LoggAggregators.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
