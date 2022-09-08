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
    [Authorize]
    public class KullaniciController : Controller
    {

        private readonly SqlDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly IMapper mapper;

        public KullaniciController
            (UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher,
            IMapper mapper)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
            this.mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
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

                    ModelState.AddModelError("", "Kullanici Adi yada Şifre Yanliş");

                }

            }

            return View(loginDTO);
        }
        [HttpGet]
        [AllowAnonymous]
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
                AppUser appUser = new AppUser { UserName = registerDTO.KullaniciAdi, Email = registerDTO.Email };

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
    }
}
