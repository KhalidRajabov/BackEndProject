using System.ComponentModel.DataAnnotations;

namespace BackEndProject.ViewModels
{
    public class ExternalLoginVM
    {
        [Required, DataType(DataType.EmailAddress)] 
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
