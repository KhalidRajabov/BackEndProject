using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class HeaderComponentVM
    {
        public Bio Bio{ get; set; }
        public List<Category> Categories { get; set; }
    }
}
