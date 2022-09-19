using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Abstract;
using FilmDukkani.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.BL.Concrete
{
    public class SepetManager : ManagerBase<Sepet>, ISepetManager
    {
        private readonly ISepetDAL sepetDAL;

        public SepetManager(ISepetDAL sepetDAL)
        {
            this.sepetDAL = sepetDAL;
        }

        public void AddToCart(string userId, int filmId, int adet)
        {
            var cart = GetSepetByUserId(userId);
            if (cart != null)
            {
                
            }
        }

        public Sepet GetSepetByUserId(string userId)
        {
            return sepetDAL.GetByUserId(userId);
        }

        public void InitCart(string userId)
        {
            sepetDAL.Add(new Sepet() { UserId = userId });
        }


    }
}
