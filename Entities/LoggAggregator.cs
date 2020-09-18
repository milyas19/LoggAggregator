using System;

namespace Entities
{
    public class LoggAggregator
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string HostName { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
    }
}
