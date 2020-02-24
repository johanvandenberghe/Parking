using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class RouteWithCarParkingsSpecification : BaseSpecification<Route>
    {
        public RouteWithCarParkingsSpecification(int routeId) : base(o => o.Id == routeId)
        {
            AddInclude(route => route.DepartureParking);
            AddInclude(route => route.ArrivalParking);
            AddInclude(route => route.Car);
        }
    }
}
