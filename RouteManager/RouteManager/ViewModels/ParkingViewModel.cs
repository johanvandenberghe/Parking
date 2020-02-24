using GeoCoordinatePortable;

namespace RouteManager.ViewModels
{
    public class ParkingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoCoordinate Position { get; set; }
    }
}
