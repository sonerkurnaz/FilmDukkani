using FilmDukkani.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.DAL.Abstract
{
    public interface ISepetDAL : IBaseRepository<Sepet>
    {
        void SepeteEkle(Film film);
        void SepeteCikar(Film film);
    }
}
