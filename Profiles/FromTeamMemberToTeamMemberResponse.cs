using AutoMapper;
using RescueTeam.Models.TeamMember;

namespace RescueTeam.Profiles
{
    public class FromTeamMemberToTeamMemberResponse : Profile
    {
        public FromTeamMemberToTeamMemberResponse()
        {
            CreateMap<DAL.Entities.TeamMember, TeamMemberSimpleResponse>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Surname,
                    opt => opt.MapFrom(s => s.Surname));

            CreateMap<DAL.Entities.TeamMember,TeamMemberPostResponse>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Surname,
                    opt => opt.MapFrom(s => s.Surname));
            
            CreateMap<DAL.Entities.TeamMember, TeamMemberGetByIdResponse>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Surname,
                    opt => opt.MapFrom(s => s.Surname));

            CreateMap<DAL.Entities.TeamMember, TeamMemberPutResponse>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Surname,
                    opt => opt.MapFrom(s => s.Surname));
        }
    }
}
