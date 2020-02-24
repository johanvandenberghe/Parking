using System.Diagnostics;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using RouteManager.Interfaces;
using RouteManager.Services;
using RouteManager.ViewModels;

namespace RouteManager.Controllers
{
    [Route("[controller]/[action]")]
    public class RouteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IRouteViewModelService _routeViewModelService;
        public readonly IRouteService _routeService;

        public RouteController(IRouteViewModelService routeViewModelService, IRouteService routeService )
        {
            _routeViewModelService = routeViewModelService;
            _routeService = routeService;
        }


        [HttpGet()]
        public async Task<IActionResult> MyRoutes()
        {
            var routes = await _routeViewModelService.GetAllRouteAsync();
            return View(routes);
        }
        
        [HttpGet()]
        public async Task<ActionResult> Edit(int? routeId)
        {
            var route = await _routeViewModelService.GetRouteEditAsync(routeId);
            return View(route);
           
        }

        [HttpPost()]
        public async Task<ActionResult> CreateOrUpadateRoute(EditRouteViewModel route)
        {
            if(route.RouteId == default(int))
                await _routeService.CreateRouteAsync(route.Name, route.CarId, route.DepartureParkingId, route.ArrivalParkingId);
            else
                await _routeService.UpadeRouteAsync(route.RouteId, route.Name, route.CarId, route.DepartureParkingId, route.ArrivalParkingId);

            var routes = await _routeViewModelService.GetAllRouteAsync();
            return RedirectToAction("MyRoutes");
        }

        [HttpGet()]
        public async Task<ActionResult> Delete(int routeId)
        {
            await _routeService.DeleteRouteAsync(routeId);

            return RedirectToAction("MyRoutes");
        }
    }
}
