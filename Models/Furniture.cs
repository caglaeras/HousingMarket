using System.ComponentModel.DataAnnotations;

namespace Housing.Models
{
    public class Furniture
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } // Optional: keep for search or other views

        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public string Condition { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string? Value { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;

        public string? ImageUrl { get; set; } // Add this

        public string? ImagePath { get; set; } // Optional: use only one of ImageUrl or ImagePath

        public bool IsReadOnly { get; set; } = false;
        public string? UserId { get; set; }
    }

}
