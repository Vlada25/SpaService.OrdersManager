using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Domain.Models.Logging
{
    public class LogMessageForCreation
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime DateTime { get; set; }
        public string Severity { get; set; }
    }
}
