using AutoMapper;
using RescueTeam.Models.Team;

namespace RescueTeam.Profiles
{
    public class FromRequestToTeam: Profile
    {

        public FromRequestToTeam()
        {
            CreateMap<TeamPostRequest,DAL.Entities.Team>()
                .ForMember(dest => dest.TeamMembers, opt => opt.Ignore()) // Ignora la mappatura di TeamMembers
                .ForMember(dest => dest.Trasport, opt => opt.MapFrom(src => src.Trasport));

            CreateMap<TeamPostRequest, DAL.Entities.Team>()
                .ForMember(dest => dest.TeamMembers, opt => opt.Ignore()) // Ignora la mappatura di TeamMembers
                .ForMember(dest => dest.Trasport, opt => opt.MapFrom(src => src.Trasport));
        }
        
      
    }
}
