using AutoMapper;
using RescueTeam.Models.Team;

namespace RescueTeam.Profiles
{
    public class FromRequestToTeam : Profile
    {

        public FromRequestToTeam()
        {
            CreateMap<TeamPostRequest, DAL.Entities.Team>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore())
                .ForMember(d => d.TeamName,
                    opt => opt.MapFrom(s => s.TeamName))
                .ForMember(d => d.Trasport,
                    opt => opt.MapFrom(s => s.Trasport))
                .ForMember(d => d.Coordinates,
                    opt => opt.MapFrom(s => s.Coordinates));

            CreateMap<TeamPutRequest, DAL.Entities.Team>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore())
                .ForMember(d => d.TeamName,
                    opt => opt.MapFrom(s => s.TeamName))
                .ForMember(d => d.Trasport,
                    opt => opt.MapFrom(s => s.Trasport))
                .ForMember(d => d.Coordinates,
                    opt => opt.MapFrom(s => s.Coordinates));


        }


    }
}

