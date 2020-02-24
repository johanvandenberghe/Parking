using ApplicationCore.Interfaces;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Parking : BaseEntity, IAggregateRoot
    {
        private Parking() { }

        public Parking(string name, double coordX, double coordY)
        {
            Name = name;
            CoordX = coordX;
            CoordY = coordY;
        }

        public string Name { get; private set; }
        public double CoordX { get; private set; }
        public double CoordY { get; private set; }

        public GeoCoordinate Position => new GeoCoordinate(CoordX , CoordY);

        public virtual ICollection<Route> RoutesDeparture { get; set; }
        public virtual ICollection<Route> RoutesDestination { get; set; }
    }
}