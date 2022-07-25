using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class HomeVM
    {
        public Bio Bio { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
