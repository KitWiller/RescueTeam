using RescueTeam.DAL.Entities;
using RescueTeam.Models.Team;
using AutoMapper;

namespace RescueTeam.Profiles
{
    public class FromTeamToTeamResponse : Profile
    {
        public FromTeamToTeamResponse()
        {
            CreateMap<DAL.Entities.Team,TeamSimpleResponse>()
                .ForMember(dest => dest.Squad, opt => opt.MapFrom(src => src.TeamMembers));


            CreateMap<DAL.Entities.Team, TeamPostResponse>()
                .ForMember(dest => dest.Squad, opt => opt.MapFrom(src => src.TeamMembers));


            CreateMap<DAL.Entities.Team, TeamGetByIdResponse>()
                .ForMember(dest => dest.Squad, opt => opt.MapFrom(src => src.TeamMembers));

            CreateMap<DAL.Entities.Team, TeamPutResponse>()
                .ForMember(dest => dest.Squad, opt => opt.MapFrom(src => src.TeamMembers));



        }  
    }
}
