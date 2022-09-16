using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDukkani.DAL.Contexts
{
    public interface IBaseEntity1
    {
        public enum Status
        {
            Active = 1,
            Modified = 2,
            Delete = 3
        }

        public interface IBaseEntity
        {

            public DateTime CreateDate { get; set; }
            public DateTime? UpdateDate { get; set; }
            public DateTime? Delete { get; set; }

            public Status Status { get; set; }
        }
    }
}
