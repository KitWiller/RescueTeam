using System.Threading.Tasks;

namespace RescueTeam.Services.Abstract.GeneralMethod
{
    public interface ICreate<TRequest, TResponse>
    {
        Task<TResponse> Create(TRequest postRequest);
    }
}
