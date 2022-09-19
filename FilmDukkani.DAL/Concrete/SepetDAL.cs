using FilmDukkani.DAL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FilmDukkani.DAL.Concrete
{
    public class SepetDAL : BaseRepository<Sepet>, ISepetDAL
    {
        public Sepet GetByUserId(string userId)
        {
            using(var context = new SqlDbContext())
            {
               return context.Sepetler
                    .Include(x => x.SepetItems)
                    //.ThenInclude(x => x.Filmler);
                    .FirstOrDefault(x => x.UserId == userId);
            }
        }
    }
}
