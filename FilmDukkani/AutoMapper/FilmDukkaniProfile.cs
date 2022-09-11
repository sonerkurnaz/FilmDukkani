using AutoMapper;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using FilmDukkani.Models.DTOs.Fimler;
using FilmDukkani.Models.DTOs.Kategoriler;

namespace FilmDukkani.AutoMapper
{
    public class FilmDukkaniProfile : Profile
    {
        public FilmDukkaniProfile()
        {
            CreateMap<Kullanici, UserRegisterDto>();
            CreateMap<UserRegisterDto,Kullanici >();

            CreateMap<KategoriCreateDto,Kategori>();
            CreateMap<Kategori, KategoriCreateDto>();

            CreateMap<KategoriListDto, Kategori>();
            CreateMap<Kategori, KategoriListDto>();

            CreateMap<FilmCreateDto,Film>();
            CreateMap<Film, FilmCreateDto>();

            CreateMap<FilmListDto, Film>();
            CreateMap<Film, FilmListDto>();

            CreateMap<FilmUpdateDto, Film>();
            CreateMap<Film, FilmUpdateDto>();






        }
    }
}
