using AutoMapper;
using RescueTeam.Models.Team;

namespace RescueTeam.Profiles
{
    public class FromTeamToTeamResponse : Profile
    {
        public FromTeamToTeamResponse()
        {
            CreateMap<DAL.Entities.Team, TeamSimpleResponse>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore())
                .ForMember(d => d.TeamName,
                    opt => opt.MapFrom(s => s.TeamName))
                .ForMember(d => d.Trasport,
                    opt => opt.MapFrom(s => s.Trasport))
                .ForMember(d => d.Coordinates,
                    opt => opt.MapFrom(s => s.Coordinates));


            CreateMap<DAL.Entities.Team, TeamGetByIdResponse>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore())
                .ForMember(d => d.TeamName,
                    opt => opt.MapFrom(s => s.TeamName))
                .ForMember(d => d.Trasport,
                    opt => opt.MapFrom(s => s.Trasport))
                .ForMember(d => d.Coordinates,
                    opt => opt.MapFrom(s => s.Coordinates));

            CreateMap<DAL.Entities.Team, TeamPostResponse>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore())
                .ForMember(d => d.TeamName,
                    opt => opt.MapFrom(s => s.TeamName))
                .ForMember(d => d.Trasport,
                    opt => opt.MapFrom(s => s.Trasport))
                .ForMember(d => d.Coordinates,
                    opt => opt.MapFrom(s => s.Coordinates));

            CreateMap<DAL.Entities.Team, TeamPutResponse>()
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
