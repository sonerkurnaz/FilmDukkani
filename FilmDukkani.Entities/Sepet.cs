using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.Entities
{
    public class Sepet : BaseEntity
    {
        
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public IList<SepetItem> SepetItems { get; set; }


    }
}
