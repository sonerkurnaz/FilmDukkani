using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Models.DTOs.Kategoriler;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriManager manager;
        private readonly SqlDbContext sqlDb;
        private readonly IMapper mapper;

        public KategoriController(SqlDbContext sqlDb, IMapper mapper)
        {
            this.sqlDb = sqlDb;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var KategoriListe = sqlDb.Kategoriler.ToList();

            IList<KategoriListDto> kategoris = mapper.Map<IList<KategoriListDto>>(KategoriListe);




            return View(kategoris);
        }
    }
}
