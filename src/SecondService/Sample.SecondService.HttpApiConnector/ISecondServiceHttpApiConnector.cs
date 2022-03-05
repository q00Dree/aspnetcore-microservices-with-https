using System.Threading.Tasks;

namespace Sample.SecondService.HttpApiConnector
{
    public interface ISecondServiceHttpApiConnector
    {
        Task<string?> HealthCheckAsync();
    }
}
