using FilmDukkani.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FilmDukkani.DAL.Contexts
{
    public class SqlDbContext : IdentityDbContext<AppUser>
    {

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
        public SqlDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FilmDukkan;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<FilmKategori> FilmKategoriler { get; set; }
        public DbSet<Fotograf> Fotograflar { get; set; }
        public DbSet<Kargo> Kargocular { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<SepetItem> SepetItems { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }



    }
}
