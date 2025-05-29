using System.ComponentModel.DataAnnotations;

namespace Housing.Models
{
    public class DeliveryContact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Service Area")]
        public string ServiceArea { get; set; }

        [Display(Name = "Notes (e.g., price)")]
        public string Notes { get; set; }

    }
}
