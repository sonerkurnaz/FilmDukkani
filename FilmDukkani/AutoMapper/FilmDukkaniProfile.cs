using AutoMapper;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs.Urunler;

namespace FilmDukkani.AutoMapper
{
    public class FilmDukkaniProfile : Profile
    {
        public FilmDukkaniProfile()
        {
            CreateMap<Urun, UrunListDto>();
            CreateMap<UrunListDto, Urun>();
        }
    }
}
