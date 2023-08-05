using AutoMapper;
using Projekt_Programowanie.Models.DTO;
using Projekt_Programowanie.Models.MODELS;
namespace Projekt_Programowanie.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Krzyzowka, KrzyzowkaDTO>();
            CreateMap<Pytanie, PytanieDTO>();
            CreateMap<Slowo, SlowoDTO>();
            CreateMap<TabelaWynikow, TabelaWynikowDTO>();
            CreateMap<Uzytkownik, UzytkownikDTO>();
            CreateMap<Wzor, WzorDTO>();
        }
    }
}
