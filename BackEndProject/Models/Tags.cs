using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TagProducts> TagProducts{ get; set; }
    }
}
