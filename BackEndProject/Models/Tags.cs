using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductTags> TagProducts{ get; set; }
    }
}
