using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IParkingService
    {
        Task CreateParkingAsync(string name, double coordX, double coordY);
    }
}