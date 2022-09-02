using FilmDukkani.BL.Abstract;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs.Kategoriler;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriManager manager;

        public KategoriController(IKategoriManager manager)
        {
            this.manager = manager;
        }
        public IActionResult Index(KategoriListDto listDto)
        {

            Kategori ktg = new();
            ktg.KategoriAdi = listDto.KategoriAdi;
            ktg.Aciklama = listDto.Aciklama;



            return View();
        }
    }
}
