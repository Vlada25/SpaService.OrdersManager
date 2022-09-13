using System.ComponentModel.DataAnnotations;

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
