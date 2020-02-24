using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICarService
    {
        Task CreateCarAsync(string brand, decimal conso, decimal startConso);
        Task UpadteCarAsync(int carId, string brand, decimal conso, decimal startConso);
    }
}