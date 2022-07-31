using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Subscribers subscribers = new Subscribers();
            Bio bio = _context.Bios.FirstOrDefault();
            FooterVM footerVM = new FooterVM();
            
            footerVM.Bio = bio;
            return View(await Task.FromResult(footerVM));
        }

    }
}
