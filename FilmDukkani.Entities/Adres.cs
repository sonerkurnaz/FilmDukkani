﻿namespace FilmDukkani.Entities
{

    public enum AdresTip
    {
        Ev,
        Is,
        Yazlik,
        Diğer
    }

    public class Adres : BaseEntity
    {
        public int Id { get; set; }
        public AdresTip? AdresTip { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public string CaddeSokak { get; set; }

    }
}
