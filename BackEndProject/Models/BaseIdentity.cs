using System;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Models
{
    public class BaseIdentity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        public Nullable<DateTime> CreatedTime { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> LastUpdatedAt { get; set; }
    }
}
