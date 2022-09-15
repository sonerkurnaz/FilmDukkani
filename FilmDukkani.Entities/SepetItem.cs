using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.Entities
{
    public class SepetItem : BaseEntity
    {
        
        public string FilmId { get; set; }
        
        public int SepetId { get; set; }
        public Sepet Sepet { get; set; }
        public int Adet { get; set; }


    }
}
