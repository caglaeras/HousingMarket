using Housing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Housing.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; } = null!;

        public string SessionId { get; set; } = null!;
    }

}
