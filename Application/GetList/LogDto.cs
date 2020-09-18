using System;
using System.Collections.Generic;
using System.Text;

namespace Application.GetList
{
    public class LogDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string HostName { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
    }
}
