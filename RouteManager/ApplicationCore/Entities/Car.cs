using System.Collections.Generic;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Car : BaseEntity, IAggregateRoot
    {
        private Car()
        {
        }

        public Car(string brand, decimal conso, decimal startConso)
        {
            Brand = brand;
            Conso = Conso;
            StartConso = StartConso;
        }

        public string Brand { get; private set; }
        public decimal Conso { get; private set; }
        public decimal StartConso { get; private set; }

        public void SetBrand(string brand)
        {
            Brand = brand;
        }

        public void SetConso(decimal conso)
        {
            Conso = conso;
        }

        public void SetStartConso(decimal startConso)
        {
            StartConso = startConso;
        }

        public ICollection<Route> Routes { get; set; }
    }
}
