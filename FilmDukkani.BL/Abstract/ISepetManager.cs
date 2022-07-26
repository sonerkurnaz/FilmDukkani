﻿using FilmDukkani.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.BL.Abstract
{
    public interface ISepetManager:IManagerBase<Sepet>
    {
        void InitCart(string userId);
        Sepet GetSepetByUserId(string userId);
        void AddToCart(string userId, int filmId, int adet);
    }
}
