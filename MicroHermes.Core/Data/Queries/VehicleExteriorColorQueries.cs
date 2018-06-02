using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleExteriorColorQueries : IVehicleExteriorColorQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleExteriorColorQueries()
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
                {16,"Turquoise"},
                {17,"White"},
                {18,"Yellow"},
                {19,"Champagne"},
                {20,"Camouflage"},
                {21,"Lime"},
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