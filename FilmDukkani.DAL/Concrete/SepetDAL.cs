using FilmDukkani.DAL.Abstract;
using FilmDukkani.Entities;
using FilmDukkani.
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.DAL.Concrete
{
    public class SepetDAL : BaseRepository<Sepet>, ISepetDAL
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SepetDAL(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void SepeteCikar(Film film)
        {
           
        }

        public void SepeteEkle(Film film)
        {
            httpContextAccessor.HttpContext.Session.
        }
    }
}
