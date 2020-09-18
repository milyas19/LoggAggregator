using System;

namespace Application.GetSingleLog
{
    public class SingleLogDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string HostName { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
    }
}
