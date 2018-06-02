using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleVehicleTypeQueries : IVehicleVehicleTypeQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleVehicleTypeQueries()
        {
            values = new Dictionary<int, string>
            {
                {1, "SUV"},
                {2, "Car"},
                {3, "Truck"},
                {4, "Van"},
                {5, "Minivan"},
            };
        }

        public int GetId(string value)
        {
            return values.First(x => x.Value.Equals(value)).Key;
        }
        
        public string GetValue(int id)
        {
            return values.First(x => x.Key.Equals(id)).Value;
        }
    }
}