﻿using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public List<AppUser> User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
