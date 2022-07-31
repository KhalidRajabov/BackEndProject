using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required, MinLength(35)]
        public string Description { get; set; }
        [Required]
        public double DiscountPercent { get; set; }
        [Required]
        public double DiscountPrice { get; set; }
        [Required]
        public double TaxPercent { get; set; }
        [Required]
        public int Count { get; set; }
        public bool IsAvailability { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsFeatured { get; set; }
        public bool Bestseller { get; set; }
        public bool NewArrival { get; set; }
        public bool InStock { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public List<IFormFile> Photo { get; set; }

        [NotMapped]
        public List<int> TagId { get; set; }


        public Nullable<DateTime> CreatedTime { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> LastUpdatedAt { get; set; }



        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        
        
        public List<ProductTags> ProductTags { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<OrderItem> OrderItem { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }
}
