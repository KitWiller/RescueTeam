using AutoMapper;
using RescueTeam.DAL.Entities;
using RescueTeam.Models.TeamMember;
using RescueTeam.Services.Abstract;

namespace RescueTeam.Services.Concrete
{
    //implementa l'interfaccia ed installa automapper con package manager console
    //comando  Install-Package Automapper
    public class TeamMemberWorkerService : ITeamMemberWorkerService
    {
        //setuppa il mapper da entità a dto e il contesto per la futura persistenza EF
        private readonly IMapper _mapper;
        private readonly RescueTeamDbContext _context;

        //costruttore che si aspetta il mapper ed il contesto
        public TeamMemberWorkerService(RescueTeamDbContext context, IMapper mapper)
        {
            _mapper=mapper;
            _context=context;
        }

        //async che si aspettano i dto delle request e ritornano response sempre in dto
        public async Task<TeamMemberPostResponse> Create(TeamMemberPostRequest postRequest)
        {
            //variabile in cui salvo il team member mappato come postrequest di tipo TeamMemberPostRequest
            var teamMembertoCreate = _mapper.Map<TeamMember>(postRequest);
            
            //il contesto aggiunge alla lista dei membri il nuovo membro mappato
            _context.TeamMembers.Add(teamMembertoCreate);

            await _context.SaveChangesAsync(); //salvo la modifica in persistenza nel context

            //ritorno la response mappata dal dto alla response
            return _mapper.Map<TeamMemberPostResponse>(teamMembertoCreate);

        }

        public async Task Delete(int id)
        {
            if (!IsValid(id))//se non è valido l'id
            {
                throw new ArgumentException();
            }

            //pesca dal contesto, togli da quella lista quel membro con quell'id che gli hai passato
            var members = _context.TeamMembers;
            members.Remove(new TeamMember {Id = id});

            var membersChanged = await _context.SaveChangesAsync();

            if (membersChanged < 1)
                throw new ArgumentException();

        }

        public async Task<TeamMemberPutResponse> Update(int id, TeamMemberPutRequest updateRequest)
        {
            if (!IsValid(id))//se non è valido l'id
            {
                throw new ArgumentException();
            }
            //prendo la lista dal contesto
            var members = _context.TeamMembers;

            var memberToUpdate = members.FirstOrDefault(x => x.id == id);

            memberToUpdate.name= updateRequest.name;
            //per tutte le proprietà che vuoi modificare

            return _mapper.Map<TeamMemberPutResponse>(memberToUpdate); 
        }


        public async Task <List<TeamMemberSimpleResponse>> ReadAll()
        {
            //pesco dal context la lista con tutti i membri
            var members = await _context.TeamMembers.ToListAsync();

            //creo nuova lista e ciclo per ogni membro lo butto dentro, mappato come lista di response
            var result = new List<TeamMemberSimpleResponse>();

            //mappa direttamente la lista 
            return (_mapper.Map<List<TeamMemberSimpleResponse>>(members));
            
       
        }

        public async Task<TeamMemberGetByIdResponse> Read(int id)
        {
            //solita condizione
            if (!IsValid(id))
                throw new ArgumentException();

            //setto quel member che stiamo cercando con quel particolare id
            //con INCLUDe include le navigation property
            var member = await _context.Members
                .SingleAsync(a => a.Id);

            //vengono mappate in questa response e ritornate
            return _mapper.Map<TeamMemberGetByIdResponse>(member);
        }




        //se id valido
        private bool IsValid(int id) => id <= 0;
    }
}
