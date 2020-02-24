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
    public class CarController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ICarViewModelService _carViewModelService;
        public readonly ICarService _carService;

        public CarController(ICarViewModelService carViewModelService, ICarService carService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _carViewModelService = carViewModelService;
            _carService = carService;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var cars = await _carViewModelService.GetAllcarAsync();
            return View(cars);
        }

        [HttpGet("{routeId}")]
        public async Task<IActionResult> CarDetail(int carId)
        {
            var parking = await _carViewModelService.GetCarAsync(carId);
            return View(parking);
        }

        [HttpPost("create")]
        public async Task CreateParking(CarViewModel car)
        {
            await _carService.CreateCarAsync(car.Brand, car.Conso, car.StartConso);
        }

        [HttpPut("Update")]
        public async Task UpdateParking(CarViewModel car)
        {
            await _carService.UpadteCarAsync(car.Id, car.Brand, car.Conso, car.StartConso);
        }
    }
}
