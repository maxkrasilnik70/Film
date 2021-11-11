using AutoMapper;
using Film.BLL.DTO;
using Film.DAL.API_Entities;
using Film.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Film.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchResult, SearchResultDto>().ReverseMap();

            CreateMap<WatchlistDto, Watchlist>()
                .ForMember(dto => dto.UserId, m => m.MapFrom(x => x.UserId))
                .ForMember(dto => dto.FilmId, m => m.MapFrom(x => x.FilmId)).ReverseMap();

            CreateMap<LastViewDto, LastView>()
                .ForMember(dto => dto.View, m => m.MapFrom(x => x.View))
                .ForMember(dto => dto.WatchlistId, m => m.MapFrom(x => x.WatchlistId)).ReverseMap();

            CreateMap<CountGenres, CountGenresDto>()
                .ForMember(m => m.Genre, dto => dto.MapFrom(x => x.Genre))
                .ForMember(m => m.QtyFilms, dto => dto.MapFrom(x => x.QtyFilms)).ReverseMap();
        }
    }
}
