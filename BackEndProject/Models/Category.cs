using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class Category:BaseIdentity
    {
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Images { get; set; }


        public Nullable<int> ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }


        public List<Product> Products { get; set; }
    }
}
