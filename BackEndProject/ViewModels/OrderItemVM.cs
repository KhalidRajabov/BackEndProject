using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class OrderItemVM
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
