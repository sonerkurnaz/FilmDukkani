using AutoMapper;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Models.DTOs.Urunler;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class UrunController : Controller
    {
        private readonly SqlDbContext context;
        private readonly IMapper mapper;

        public UrunController(SqlDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {

            var UrunList = context.Urunler.ToList();
            IList<UrunListDto> urunler = mapper.Map<IList<UrunListDto>>(UrunList);
            return View(UrunList);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
