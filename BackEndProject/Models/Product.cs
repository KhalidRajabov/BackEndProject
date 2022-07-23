using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public int Count { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsFeatured { get; set; }
        public bool Bestseller { get; set; }
        public bool NewArrival { get; set; }
        public bool InStock { get; set; }
        public bool IsDeleted { get; set; }

        public Nullable<DateTime> CreatedTime { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> LastUpdatedAt { get; set; }



        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        
        
        public List<TagProducts> TagProducts { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }
}
