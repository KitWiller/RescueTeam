using System.Threading.Tasks;

namespace RescueTeam.Services.Abstract.GeneralMethod
{
    public interface IRead<TResponse>
    {
        Task<TResponse> Read(int id);
    }
}