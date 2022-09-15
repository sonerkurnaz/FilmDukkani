using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.Entities
{
    public class Fotograf : BaseEntity
    {
        
        public string? Path { get; set; }

        public byte[]? Foto { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
        
    }
}
