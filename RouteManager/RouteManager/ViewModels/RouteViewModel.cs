namespace RouteManager.ViewModels
{
    public class RouteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ParkingViewModel DepartureParking { get; set; }
        public ParkingViewModel ArrivalParking { get; set; }
        public CarViewModel Car { get; set; }
        public decimal Distance => (decimal)DepartureParking.Position.GetDistanceTo(ArrivalParking.Position);
        public decimal Conso => (Distance * Car.Conso) + Car.StartConso ;
    }
}