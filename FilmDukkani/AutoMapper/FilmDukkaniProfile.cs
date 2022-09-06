using AutoMapper;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs;
using FilmDukkani.Models.DTOs.Kategoriler;

namespace FilmDukkani.AutoMapper
{
    public class FilmDukkaniProfile : Profile
    {
        public FilmDukkaniProfile()
        {
            CreateMap<Kullanici, UserRegisterDto>();
            CreateMap<UserRegisterDto,Kullanici >();




        }
    }
}
