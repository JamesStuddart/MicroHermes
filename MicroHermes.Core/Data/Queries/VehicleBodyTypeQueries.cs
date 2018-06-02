using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleBodyTypeQueries : IVehicleBodyTypeQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleBodyTypeQueries()
        {
            values = new Dictionary<int, string>
            {
                {1,"4Dr SUV"},
                {2,"Convertible SUV"},
                {3,"Sedan"},
                {4,"Coupe"},
                {5,"Convertible"},
                {6,"Wagon"},
                {7,"Crew Cab Pickup"},
                {8,"Extended Cab Pickup"},
                {9,"Passenger Van"},
                {10,"Cargo Van"},
                {11,"Regular Cab Pickup"},
                {12,"Cargo Minivan"},
                {13,"Passenger Minivan"},
                {14,"4Dr Hatchback"},
                {15,"2Dr Hatchback"},
                {16,"2Dr SUV"},
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