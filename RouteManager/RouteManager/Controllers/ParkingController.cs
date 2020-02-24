using System.Diagnostics;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RouteManager.Interfaces;
using RouteManager.Services;
using RouteManager.ViewModels;

namespace RouteManager.Controllers
{
    [Route("[controller]/[action]")]
    public class ParkingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IParkingViewModelService _parkingViewModelService;
        public readonly IParkingService _parkingService;

        public ParkingController(IParkingViewModelService parkingViewModelService, IParkingService parkingService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _parkingViewModelService = parkingViewModelService;
            _parkingService = parkingService;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var parkings = await _parkingViewModelService.GetAllParkingAsync();
            return View(parkings);
        }

        [HttpGet("{routeId}")]
        public async Task<IActionResult> PakingDetail(int routeId)
        {
            var parking = await _parkingViewModelService.GetParkingAsync(routeId);
            return View(parking);
        }

        [HttpPost()]
        public async Task CreateParking(ParkingViewModel parking)
        {
            await _parkingService.CreateParkingAsync(parking.Name, parking.Position.Latitude, parking.Position.Longitude);
        }

        [HttpPut()]
        public async Task UpdateParking(ParkingViewModel parking)
        {
            await _parkingService.CreateParkingAsync(parking.Name, parking.Position.Latitude, parking.Position.Longitude);
        }


    }
}
