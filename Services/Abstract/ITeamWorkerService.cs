using RescueTeam.Services.Abstract.GeneralMethod;
using System.Collections.Generic;

namespace RescueTeam.Services
{
    public interface ITeamWorkerService :
        ICreate<TeamWorkerPostRequest, TeamWorkerPostResponse>,
        IDelete,
        IUpdate<TeamWorkerPutRequest, TeamWorkerPutResponse>,
        IRead<TeamWorkerGetByIdResponse>,
        IReadAll<TeamWorkerGetAllResponse>

    {
    }
}
