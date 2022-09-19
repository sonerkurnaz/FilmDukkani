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
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        

        public KullaniciController
            (
            IKullaniciManager manager,
            IMapper mapper,
            SqlDbContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher
            
            )
        {
            this.manager = manager;
            this.mapper = mapper;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
            
        }

        [AllowAnonymous]
        public IActionResult Login(string url)
        {

            return View(new UserLoginDto { ReturnUrl = url });
        }
        [HttpPost,ValidateAntiForgeryToken,AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto loginDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginDTO.KullaniciAdi);
                if (user != null)
                {
                    var signInResult = await signInManager.PasswordSignInAsync(user, loginDTO.Sifre, false, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }

                    ModelState.AddModelError("", "Kullanici Adi yada Şifre Yanliş");

                }

            }

            return View(loginDTO);
        }


        [AllowAnonymous]
        public IActionResult Register()
        {
            UserRegisterDto dTO = new();
            return View(dTO);
        }

        [HttpPost, ValidateAntiForgeryToken,AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDto registerDTO)
        {


            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser { UserName = registerDTO.KullaniciAdi, Email = registerDTO.Email };

                var result = await userManager.CreateAsync(appUser , registerDTO.Sifre);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(registerDTO);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            UserUpdateDto userUpdateDto = new UserUpdateDto(user);

            return View(userUpdateDto);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                //user.UserName = userUpdateDTO.KullaniciAdi;
                Kullanici kullanici = mapper.Map<Kullanici>(userUpdateDTO);
                if (userUpdateDTO.Sifre != null)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, userUpdateDTO.Sifre);
                }
                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userUpdateDTO);
        }
    }
}

