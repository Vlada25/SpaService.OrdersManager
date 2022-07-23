using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.DTO.Feedback
{
    public class FeedbackForUpdateDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Mark { get; set; }
    }
}
