using RescueTeam.Services.Abstract.GeneralMethod;
using System.Collections.Generic;

namespace RescueTeam.Services
{
    public interface IMissionService :
        ICreate<MissionPostRequest, MissionPostResponse>,
        IDelete,
        IUpdate<MissionPutRequest, MissionPutResponse>,
        IRead<MissionGetByIdResponse>,
        IReadAll<MissionGetAllResponse>

    {
    }
}
