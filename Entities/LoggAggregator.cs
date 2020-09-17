using System;

namespace Entities
{
    public class LoggAggregator
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string HostName { get; set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }
    }

    public enum Severity
    {
        Trace = 1,
        Information = 2,
        Debug = 3,
        Warning = 4,
        Error = 5,
        Critical = 6
    }
}
