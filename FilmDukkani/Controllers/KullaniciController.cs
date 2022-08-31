using FilmDukkani.BL.Abstract;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager manager;

        public KullaniciController(IKullaniciManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
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
                Kullanici yeniKullanici = new();
                yeniKullanici.Adi = dTO.Ad;
                yeniKullanici.Soyadi = dTO.Soyad;
                yeniKullanici.KullaniciAdi = dTO.KullaniciAdi;
                yeniKullanici.Email = dTO.Email;
                yeniKullanici.Sifre = dTO.Sifre;


            }
            return View(dTO);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
