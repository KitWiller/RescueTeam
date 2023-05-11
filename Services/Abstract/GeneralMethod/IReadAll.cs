using System.Threading.Tasks;

namespace RescueTeam.Services.Abstract.GeneralMethod
{
    public interface IReadAll<TResponse>
    {
        Task<TResponse> ReadAll();
    }

}