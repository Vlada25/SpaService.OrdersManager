using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Domain.Models
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Mark { get; set; }
        public Guid OrderId { get; set; }
    }
}
