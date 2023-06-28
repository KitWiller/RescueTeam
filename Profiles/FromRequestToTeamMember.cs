using AutoMapper;
using RescueTeam.Models.TeamMember;

namespace RescueTeam.Profiles
{
    public class FromRequestToTeamMember : Profile
    {
        public FromRequestToTeamMember()
        {
            CreateMap<TeamMemberPostRequest, DAL.Entities.TeamMember>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore())
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Surname,
                    opt => opt.MapFrom(s => s.Surname));


            CreateMap<TeamMemberPutRequest, DAL.Entities.TeamMember>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore())
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Surname,
                   opt => opt.MapFrom(s => s.Surname));

        }
    }
}
