using System.Threading.Tasks;

namespace RescueTeam.Services.Abstract.GeneralMethod
{
    public interface IUpdate<TRequest, TResponse>
    {
        Task<TResponse> Update(int id, TRequest updateRequest);
    }

    public interface IUpdate<TRequest>
    {
        Task Update(int id, TRequest updateRequest);
    }
}