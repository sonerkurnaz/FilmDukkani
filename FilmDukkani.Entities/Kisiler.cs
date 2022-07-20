namespace FilmDukkani.Entities
{
    public class Kisiler : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TCKN { get; set; }
        public string Mail { get; set; }
        public string Gsm { get; set; }
        public string KrediKartNo { get; set; }
        public string KrediKartSkt { get; set; }
        public string KrediKartCvc { get; set; }
        public string Sifre { get; set; }


        public IList<Adres> Adresler { get; set; }

    }
}
