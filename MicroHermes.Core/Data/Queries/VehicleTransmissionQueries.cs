using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleTransmissionQueries : IVehicleTransmissionQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleTransmissionQueries()
        {
            values = new Dictionary<int, string>
            {
                {1,"Automatic"},
                {2,"Manual"},
                {3,"Automated manual"},
                {4,"Unknown"},
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