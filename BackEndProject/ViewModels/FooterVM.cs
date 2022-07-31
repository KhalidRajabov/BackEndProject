using BackEndProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class FooterVM
    {
        public int Id { get; set; }
        public Bio Bio { get; set; }
        public string Email { get; set; }
    }
}
