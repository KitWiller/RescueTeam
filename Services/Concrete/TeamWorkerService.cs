using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RescueTeam.DAL;
using RescueTeam.DAL.Entities;
using RescueTeam.Models.Team;
using RescueTeam.Models.TeamMember;

namespace RescueTeam.Services.Concrete
{
    public class TeamWorkerService : ITeamWorkerService
    {
        private readonly IMapper _mapper;
        private readonly RescueTeamDbContext _context;


        public TeamWorkerService(IMapper mapper, RescueTeamDbContext context)
        {
            _mapper=mapper;
            _context=context;
        }


        public async Task<TeamPostResponse> Create(TeamPostRequest postRequest)
        {
            //variabile in cui salvo il team member mappato come postrequest di tipo teamPostRequest
            var teamToCreate = _mapper.Map<Team>(postRequest);

            //il contesto aggiunge alla lista dei membri il nuovo membro mappato
            _context.Teams.Add(teamToCreate);

            await _context.SaveChangesAsync(); //salvo la modifica in persistenza nel context

            //ritorno la response mappata dal dto alla response
            return _mapper.Map<TeamPostResponse>(teamToCreate);

        }

        public async Task<TeamPutResponse> Update(int id, TeamPutRequest updateRequest)
        {

            //prendo la lista dal contesto
            var teamToUpdate = await _context.Teams
               // .Include(t => t.TeamMembers)
                .FirstOrDefaultAsync(t => t.Id == id);

            teamToUpdate.TeamName= updateRequest.TeamName;
            teamToUpdate.Coordinates= updateRequest.Coordinates;
            teamToUpdate.Trasport= updateRequest.Trasport;

            //foreach (var member in updateRequest.Squad)
            //{
            //    var memberToUpdate = teamToUpdate.TeamMembers.FirstOrDefault
            //        (m => m.Id == member.Id);

            //    if (memberToUpdate != null)
            //    {
            //        memberToUpdate.Name = member.Name;
            //        memberToUpdate.Surname = member.Surname;
            //        memberToUpdate.BirthDate = member.BirthDate;
            //        memberToUpdate.CurrentTeamId = member.CurrentTeamId;
            //    }
            //}

            await _context.SaveChangesAsync();

            return _mapper.Map<TeamPutResponse>(teamToUpdate);
        }

        //public async Task<TeamPutResponse> UpdateInTeamMembers(int teamId, int teamMemberId)
        //{   
        //    var teamToUpdate = await _context.Teams //prendo team dal contesto con quell'id
        //        // .Include(t => t.TeamMembers)
        //        .FirstOrDefaultAsync(t => t.Id == teamId);

        //    if (teamToUpdate != null)
        //    {
        //        var membertoUpdate = await _context.TeamMembers.FirstOrDefaultAsync(t => t.Id == teamMemberId);
        //        //prendo membro da aggiungere al team

        //        if (membertoUpdate != null)
        //        {
        //            teamToUpdate.TeamMembers.Add(membertoUpdate);
        //        }

        //        await _context.SaveChangesAsync();
                
        //    }
        //    return _mapper.Map<TeamPutResponse>(teamToUpdate);
        //}


        public async Task<List<TeamSimpleResponse>> ReadAll()
        {
            var teams = await _context.Teams
                .Include(t => t.TeamMembers)
                .ToListAsync();

            var result = new List<TeamSimpleResponse>();

            return (_mapper.Map<List<TeamSimpleResponse>>(teams));


        }

        public async Task<TeamGetByIdResponse> Read(int id)
        {

            //setto quel member che stiamo cercando con quel particolare id
            //con INCLUDe include le navigation property
            var team = await _context.Teams
                .Include(t => t.TeamMembers)
                .SingleOrDefaultAsync(a => a.Id == id);

            //vengono mappate in questa response e ritornate
            return _mapper.Map<TeamGetByIdResponse>(team);
        }

        public async Task Delete(int id)
        {
            var teamToDelete = _context.Teams.FindAsync(id);

            _context.Remove(teamToDelete);

            var teamChanged = await _context.SaveChangesAsync();

            if (teamChanged < 1)
                throw new ArgumentException();

        }


    }
}
