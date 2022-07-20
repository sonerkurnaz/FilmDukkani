namespace FilmDukkani.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        private DateTime _createDate = DateTime.Now;

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }


    }
}
