using System;
using System.Collections.Generic;

namespace ArchitectNetLDAP.Models
{
    public class LogModel
    {
        public LogModel()
        {
            Logs = new List<LogEntry>();
        }
        public List<LogEntry> Logs { get; set; }
    }

    public class LogEntry
    {
        public string Username { get; set; }
        public DateTime LoginDate { get; set; }
    }
}