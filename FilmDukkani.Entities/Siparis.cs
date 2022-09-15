using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.Entities
{
    public class Siparis : BaseEntity
    {
        
        public string SiparisAdı { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

    }
}
