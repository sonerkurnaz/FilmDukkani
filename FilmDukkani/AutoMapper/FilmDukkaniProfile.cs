using AutoMapper;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using FilmDukkani.Models.DTOs.Adresler;
using FilmDukkani.Models.DTOs.Fimler;
using FilmDukkani.Models.DTOs.Kategoriler;
using FilmDukkani.Models.DTOs.Kullanicilar;

namespace FilmDukkani.AutoMapper
{
    public class FilmDukkaniProfile : Profile
    {
        public FilmDukkaniProfile()
        {           
            #region Kullanıcı
            CreateMap<Kullanici, UserRegisterDto>();
            CreateMap<UserRegisterDto, Kullanici>();

            CreateMap<Kullanici, UserLoginDto>();
            CreateMap<UserLoginDto, Kullanici>();

            CreateMap<Kullanici, UserUpdateDto>();
            CreateMap<UserUpdateDto, Kullanici>();

            #endregion

            #region Kategori
            CreateMap<KategoriCreateDto, Kategori>();
            CreateMap<Kategori, KategoriCreateDto>();

            CreateMap<KategoriUpdateDto, Kategori>();
            CreateMap<Kategori, KategoriUpdateDto>();
            
            CreateMap<KategoriListDto, Kategori>();
            CreateMap<Kategori, KategoriListDto>();
            #endregion

            #region Film
            CreateMap<FilmCreateDto, Film>();
            CreateMap<Film, FilmCreateDto>();

            CreateMap<FilmListDto, Film>();
            CreateMap<Film, FilmListDto>();

            CreateMap<FilmUpdateDto, Film>();
            CreateMap<Film, FilmUpdateDto>();
            #endregion

            #region Adres
            CreateMap<AdresCreateDto, Adres>();
            CreateMap<Adres, AdresCreateDto>();

            CreateMap<AdresUpdateDto, Adres>();
            CreateMap<Adres, AdresUpdateDto>();
            #endregion
        }
    }
}
