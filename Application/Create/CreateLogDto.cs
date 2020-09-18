using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Create
{
    public class CreateLogDto
    {
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
        public string HostName { get; set; }
        public string Severity { get; set; }
    }
}
