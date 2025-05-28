using System.ComponentModel.DataAnnotations;

namespace Housing.Models
{
    public class PaymentViewModel
    {
        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Delivery Person")]
        public int SelectedDeliveryId { get; set; }

        public List<DeliveryContact> DeliveryOptions { get; set; } = new();
    }
}
