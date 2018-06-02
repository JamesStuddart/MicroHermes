using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleInteriorColorQueries : IVehicleInteriorColorQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleInteriorColorQueries()
        {
            values = new Dictionary<int, string>
            {
                {1,"Beige"},
                {2,"Black"},
                {3,"Blue"},
                {4,"Brown"},
                {5,"Burgundy"},
                {6,"Charcoal"},
                {7,"Gold"},
                {8,"Gray"},
                {9,"Green"},
                {10,"Off-white"},
                {11,"Orange"},
                {12,"Pink"},
                {13,"Purple"},
                {14,"Red"},
                {15,"Silver"},
                {16,"Tan"},
                {17,"Turquoise"},
                {18,"White"},
                {19,"Yellow"},
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