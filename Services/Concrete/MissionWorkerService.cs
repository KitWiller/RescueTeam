using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RescueTeam.DAL;
using RescueTeam.DAL.Entities;
using RescueTeam.Models.Mission;
using RescueTeam.Models.TeamMember;
using RescueTeam.Services.Abstract;


namespace RescueTeam.Services.Concrete
{
    public class MissionWorkerService : IMissionWorkerService
    {
        //setuppa il mapper da entità a dto e il contesto per la futura persistenza EF
        private readonly IMapper _mapper;
        private readonly RescueTeamDbContext _context;

        //costruttore che si aspetta il mapper ed il contesto
        public MissionWorkerService(RescueTeamDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        //async che si aspettano i dto delle request e ritornano response sempre in dto
        public async Task<MissionPostResponse> Create(MissionPostRequest postRequest)
        {
            //variabile in cui salvo il team member mappato come postrequest di tipo MissionPostRequest
            var missionToCreate = _mapper.Map<Mission>(postRequest);

            //il contesto aggiunge alla lista dei membri il nuovo membro mappato
            _context.Missions.Add(missionToCreate);

            await _context.SaveChangesAsync(); //salvo la modifica in persistenza nel context

            //ritorno la response mappata dal dto alla response
            return _mapper.Map<MissionPostResponse>(missionToCreate);

        }

        public async Task Delete(int id)
        {
            if (!IsValid(id)) //se non è valido l'id
            {
                throw new ArgumentException();
            }

            //pesca dal contesto, togli da quella lista quel membro con quell'id che gli hai passato
            var members = _context.Missions;
            members.Remove(new Mission {Id = id});

            var membersChanged = await _context.SaveChangesAsync();

            if (membersChanged < 1)
                throw new ArgumentException();

        }

        public async Task<MissionPutResponse> Update(int id, MissionPutRequest updateRequest)
        {
            if (!IsValid(id))//se non è valido l'id
            {
                throw new ArgumentException();
            }
            //prendo la lista dal contesto
            var missions = _context.Missions;

            var mission = missions.FirstOrDefault(x => x.Id == id);

            var memberToUpdate = missions.FirstOrDefault(x => x.Id == id);
            //per tutte le proprietà che vuoi modificare

            return _mapper.Map<MissionPutResponse>(memberToUpdate);
        }


        public async Task<List<MissionSimpleResponse>> ReadAll()
        {
            //pesco dal context la lista con tutti i membri
            var members = await _context.Missions.ToListAsync();

            //creo nuova lista e ciclo per ogni membro lo butto dentro, mappato come lista di response
            var result = new List<MissionSimpleResponse>();

            //mappa direttamente la lista 
            return (_mapper.Map<List<MissionSimpleResponse>>(members));


        }

        public async Task<MissionGetByIdResponse> Read(int id)
        {
            //solita condizione
            if (!IsValid(id))
                throw new ArgumentException();

            //setto quel member che stiamo cercando con quel particolare id
            //con INCLUDe include le navigation property
            var member = await _context.Missions
                .SingleAsync(a => a.Id == id);

            //vengono mappate in questa response e ritornate
            return _mapper.Map<MissionGetByIdResponse>(member);



            
        }

        //se id valido
        bool IsValid(int id) => id <= 0;
    }
}
