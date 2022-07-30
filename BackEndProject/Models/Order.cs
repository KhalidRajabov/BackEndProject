using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedAt { get; set; }
        
        public double Price { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
   
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string Companyname { get; set; }


        public OrderStatus OrderStatus { get; set; }



        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<OrderItem> OrderItems{ get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Approved,
        Refused
    }

}
