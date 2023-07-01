using RescueTeam.Services.Abstract.GeneralMethod;
using System.Collections.Generic;
using RescueTeam.Models.Team;

namespace RescueTeam.Services
{
    public interface ITeamWorkerService :
        ICreate<TeamPostRequest, TeamPostResponse>,
        IDelete,
        IUpdate<TeamPutRequest, TeamPutResponse>,
        IRead<TeamGetByIdResponse>,
        IReadAll<List<TeamSimpleResponse>>
    {
        Task<TeamPutResponse> UpdateInTeamMembers(int teamId, int teamMemberId);
    };
   
    
}   
