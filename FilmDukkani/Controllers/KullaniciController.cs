using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using FilmDukkani.Models.DTOs.Kullanicilar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmDukkani.Controllers
{
    //[Authorize]
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager manager;
        private readonly IMapper mapper;
        private readonly SqlDbContext context;

        public KullaniciController
            (
            IKullaniciManager manager,
            IMapper mapper,
            SqlDbContext context
            
            )
        {
            this.manager = manager;
            this.mapper = mapper;
            this.context = context;
        }

        // [AllowAnonymous]
        public IActionResult Login(string url)
        {

            return View(new UserLoginDto { ReturnUrl = url });
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDTO)
        {
            if (ModelState.IsValid)
            {
                Kullanici kullanici=mapper.Map<Kullanici>(loginDTO);
                var user = manager.GetAll(p => p.KullaniciAdi == loginDTO.KullaniciAdi && p.Sifre == loginDTO.Sifre)
                                    .FirstOrDefault();

                //if (user != null)
                //{
                //    var claims = new List<Claim>
                //    {
                //        new Claim(ClaimTypes.Name,user.KullaniciAdi),
                //        new Claim(ClaimTypes.Email,user.Email),
                       
                //    };

                //    var userIdentity = new ClaimsIdentity(claims, "login");
                //    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                //    await HttpContext.SignInAsync(principal);

                //    return RedirectToAction("Index", "Home");
                //}


            }

            return View(loginDTO);
        }


        //[AllowAnonymous]
        public IActionResult Register()
        {
            UserRegisterDto dTO = new();
            return View(dTO);
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto registerDTO)
        {
           
            if (ModelState.IsValid)
            {
                Kullanici kullanici = mapper.Map<Kullanici>(registerDTO);
                manager.Add(kullanici);
                context.SaveChanges();
                
                
                
            }
            return View(registerDTO);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Edit(UserUpdateDto updateDto)
        {
            var user = mapper.Map<Kullanici>(updateDto);



            return View(user);
        }
        [HttpPost]
        public IActionResult Edit()
        {
            UserUpdateDto userUpdateDto = new UserUpdateDto();
            var result = mapper.Map<Kullanici>(userUpdateDto);
            manager.Update(result);
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
