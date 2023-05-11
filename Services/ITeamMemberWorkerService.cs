using RescueTeam.Services.Abstract.GeneralMethod;
using System.Collections.Generic;

namespace RescueTeam.Services
{
    public interface ITeamMemberWorkerService :
        ICreate<TeamMemberWorkerPostRequest, TeamMemberWorkerPostResponse>,
        IDelete,
        IUpdate<TeamMemberWorkerPutRequest, TeamMemberWorkerPutResponse>,
        IRead<TeamMemberWorkerGetByIdResponse>,
        IReadAll<TeamMemberWorkerGetAllResponse>

    {
    }
}
