using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Domain.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Not Started")]
        NotStarted,

        [Display(Name = "In Process")]
        InProcess,

        [Display(Name = "Done")]
        Done,

        [Display(Name = "Canceled")]
        Canceled
    }
}
