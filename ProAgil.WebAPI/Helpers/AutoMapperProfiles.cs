using System;
using System.Linq;
using AutoMapper;
using ProAgil.Domain;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToString("yyyy-MM-dd HH:mm:ss"));

            CreateMap<Evento, EventoDto>()
            .ForMember(dest => dest.Palestrantes, opt => {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
            }).ReverseMap();
            CreateMap<Palestrante, PalestranteDto>()
            .ForMember(dest => dest.Eventos, opt => {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
            }).ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
        }
    }
}
