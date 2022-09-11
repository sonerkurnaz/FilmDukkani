using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using FilmDukkani.Models.DTOs.Kullanicilar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    //[Authorize]
    public class KullaniciController : Controller
    {

        
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        
        public KullaniciController
            (
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher
            )
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
            
        }
        [HttpGet]
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
                AppUser user = await userManager.FindByNameAsync(loginDTO.KullaniciAdi);
                if (user != null)
                {
                    var signInResult = await signInManager.PasswordSignInAsync(user, loginDTO.Sifre, false, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Kullanıcı adı ya da Şifre yanlış");

                }

            }

            return View(loginDTO);
        }
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Register()
        {
            UserRegisterDto dTO = new();
            return View(dTO);
        }
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]

        public async Task<IActionResult> Register(UserRegisterDto registerDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser {  UserName = registerDTO.KullaniciAdi, Email = registerDTO.Email };

                var result = await userManager.CreateAsync(appUser, registerDTO.Sifre);

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
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                user.UserName = userUpdateDto.KullaniciAdi;
                if (userUpdateDto.Sifre != null)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, userUpdateDto.Sifre);
                }
                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userUpdateDto);
        }
    }
}
