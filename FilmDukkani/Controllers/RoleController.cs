﻿using FilmDukkani.Models.DTOs.Kullanicilar;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{


    //[Authorize(Roles = "admin")]
    //[Authorize(Roles = "manager")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(name);
        }
        public async Task<IActionResult> AssignedUser(string id)
        {
            IdentityRole identityRole = await roleManager.FindByIdAsync(id);
            List<AppUser> hasRole = new List<AppUser>();
            List<AppUser> hasNotRole = new List<AppUser>();
            var list = userManager.Users.ToList(); //İşe yaramadı
            foreach (AppUser user in list)
            {
                //var list = await userManager.IsInRoleAsync(user, identityRole.Name) ? hasRole : hasNotRole;
                //list.Add(user);
                bool sonuc = await userManager.IsInRoleAsync(user, identityRole.Name);
                if (sonuc)
                {
                    hasRole.Add(user);
                }
                else
                {
                    hasNotRole.Add(user);
                }

            }
            RolAtamaDto atamaDto = new RolAtamaDto
            {
                Role = identityRole,
                HasRole = hasRole,
                HasNotRole = hasNotRole,
                RoleName = identityRole.Name

            };
            return View(atamaDto);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignedUser(RolAtamaDto roleDTO)
        {
            IdentityResult result;
            string[] addIds = roleDTO.AddIds;
            string[] delIds = roleDTO.DeleteIds;


            if (addIds != null)
            {
                foreach (var userId in addIds)
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    result = await userManager.AddToRoleAsync(user, roleDTO.RoleName);
                }


            }
            if (delIds != null)
            {
                foreach (var userId in delIds)
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    result = await userManager.RemoveFromRoleAsync(user, roleDTO.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
