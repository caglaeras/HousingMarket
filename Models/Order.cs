using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Housing.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }  // siparişi veren kullanıcı

        [ForeignKey("Furniture")]
        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
