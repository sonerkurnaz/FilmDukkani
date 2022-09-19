using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Models.DTOs.Sepet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class SepetController : Controller
    {
        private readonly ISepetManager sepetManager;
        private readonly UserManager<AppUser> userManager;

        public SepetController(ISepetManager sepetManager, UserManager<AppUser> userManager)
        {
            this.sepetManager = sepetManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            
            var cart = sepetManager.GetSepetByUserId(userManager.GetUserId(User));
            return View(new SepetDto()
            {

                SepetId = cart.Id,
                SepetItems = cart.SepetItems.Select(x => new SepetItemModel()
                {

                    SepetItemId = x.Id,
                   
                    




                }).ToList()

            });
        }
        [HttpPost]
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}
