using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleDriveTrainQueries : IVehicleDriveTrainQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleDriveTrainQueries()
        {
            values = new Dictionary<int, string>
            {
                {1,"4WD"},
                {2,"FWD"},
                {3,"AWD"},
                {4,"RWD"},
                {5,"Unknown"},
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