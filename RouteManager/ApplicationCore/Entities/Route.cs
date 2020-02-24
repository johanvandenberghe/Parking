using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities
{
    public class Route : BaseEntity, IAggregateRoot
    {
        private Route()
        {
        }

        public Route(string name, Car car, Parking departureParking, Parking arrivalParking)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(car, nameof(car));
            Guard.Against.Null(departureParking, nameof(departureParking));
            Guard.Against.Null(arrivalParking, nameof(arrivalParking));

            Name = name;
            Car = car;
            DepartureParking = departureParking;
            ArrivalParking = arrivalParking;
        }

        public string Name { get; private set; }

        public int DepartureParkingId { get; private set; }
        public Parking DepartureParking { get; private set; }

        public int ArrivalParkingId { get; private set; }
        public Parking ArrivalParking { get; private set; }

        public int CarId { get; private set; }
        public Car Car { get; private set; }

        public void SetDeparture(Parking departure)
        {
            DepartureParking = departure;
            DepartureParkingId = departure.Id;
        }

        public void SetDestination(Parking destination)
        {
            ArrivalParking = destination;
            ArrivalParkingId = destination.Id;
        }

        public void SetCar(Car car)
        {
            Car = car;
            CarId = Car.Id;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}