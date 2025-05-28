using System.Collections.Generic;
using Housing.Models;

namespace Housing.ViewModels
{
    public class FurnitureDetailViewModel
    {
        public Furniture Furniture { get; set; }
        public List<Furniture> Suggestions { get; set; }
    }
}
