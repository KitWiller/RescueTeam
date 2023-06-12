using RescueTeam.Services.Abstract.GeneralMethod;
using System.Collections.Generic;
using RescueTeam.Models.Mission;

namespace RescueTeam.Services
{
    public interface IMissionWorkerService :
        ICreate<MissionPostRequest, MissionPostResponse>,
        IDelete,
        IUpdate<MissionPutRequest, MissionPutResponse>,
        IRead<MissionGetByIdResponse>,
        IReadAll<List<MissionSimpleResponse>>   

    {
    }
}
