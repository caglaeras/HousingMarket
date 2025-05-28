using System.Collections.Generic;

namespace Housing.Models
{
    public class CartViewModel
    {
        public List<Furniture> CartItems { get; set; }
        public List<Furniture> Suggestions { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public CartViewModel()
        {
            CartItems = new List<Furniture>();
            Suggestions = new List<Furniture>();
            Name = string.Empty;
            PhoneNumber = string.Empty;
        }
    }



}
