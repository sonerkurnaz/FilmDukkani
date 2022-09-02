using FilmDukkani.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmDukkani.DAL.Contexts
{
    public class SqlDbContext : DbContext
    {

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
        public SqlDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FilmDukkan;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Filmler> FilmDatalari { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

    }
}
