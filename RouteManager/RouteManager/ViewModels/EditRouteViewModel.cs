using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RouteManager.ViewModels
{
    public class EditRouteViewModel
    {
        public int RouteId { get; set; }
        public string Name { get; set; }
        public int DepartureParkingId { get; set; }
        public int ArrivalParkingId { get; set; }
        public int CarId { get; set; }
        public List<SelectListItem> DepartureParkings { get; set; }
        public List<SelectListItem> DestinationParkings { get; set; }
        public List<SelectListItem> Cars { get; set; }
    }
}