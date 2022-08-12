﻿using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KullaniciController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            UserRegisterDTO dTO = new();
            return View(dTO);
        }
        [HttpPost]
        public IActionResult Register(UserRegisterDTO dTO)
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
