using RescueTeam.Services.Abstract.GeneralMethod;
using System.Collections.Generic;
using RescueTeam.Services.Concrete;
using RescueTeam.Models.TeamMember;

namespace RescueTeam.Services
{
    public interface ITeamMemberWorkerService :
        ICreate<TeamMemberPostRequest, TeamMemberPostResponse>,
        IDelete,
        IUpdate<TeamMemberPutRequest, TeamMemberPutResponse>,
        IRead<TeamMemberGetByIdResponse>,
        IReadAll<List<TeamMemberSimpleResponse>> { }
}
