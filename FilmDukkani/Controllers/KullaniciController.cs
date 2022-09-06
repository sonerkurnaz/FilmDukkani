using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using FilmDukkani.Models.DTOs.Kullanicilar;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager manager;
        private readonly SqlDbContext context;
        private readonly IMapper mapper;

        public KullaniciController(IKullaniciManager manager,IMapper mapper)
        {
            this.manager = manager;
            
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginDto userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = manager.GetAll(p => p.KullaniciAdi == userLogin.KullaniciAdi && p.Sifre == userLogin.Sifre)
                                   .FirstOrDefault();

                if (user != null)
                {
                    RedirectToAction("Index", "Home");
                }

            }
            return View(userLogin);
        }
        [HttpGet]
        public IActionResult Register()
        {
            UserRegisterDto dTO = new();
            return View(dTO);
        }
        [HttpPost]
        public IActionResult Register(UserRegisterDto dTO)
        {

            if (ModelState.IsValid)
            {
                return View(dTO);
            }
            var result = mapper.Map<Kullanici>(dTO);
            manager.Add(result);
            return RedirectToAction("Index", "Home");
            
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
