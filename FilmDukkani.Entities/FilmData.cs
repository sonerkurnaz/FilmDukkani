﻿namespace FilmDukkani.Entities
{
    public class FilmData : BaseEntity
    {
        public string FilmAdi { get; set; }
        public string Aciklama { get; set; }
        public string Yonetmeni { get; set; }
        public string Ozeti { get; set; }
        public int YapimYili { get; set; }
        public string AltYazilari { get; set; }

    }
}
