using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleMakeQueries : IVehicleMakeQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleMakeQueries()
        {
            values = new Dictionary<int, string>
            {
                {1,"Hummer"},
                {2,"Acura"},
                {3,"Honda"},
                {4,"Dodge"},
                {5,"Chrysler"},
                {6,"Jeep"},
                {7,"Ram"},
                {8,"Ford"},
                {9,"Buick"},
                {10,"Cadillac"},
                {11,"GMC"},
                {12,"Lincoln"},
                {13,"Nissan"},
                {14,"Toyota"},
                {15,"Volkswagen"},
                {16,"Mazda"},
                {17,"Lexus"},
                {18,"Fiat"},
                {19,"Mitsubishi"},
                {20,"Mercedes-Benz"},
                {21,"BMW"},
                {22,"Infiniti"},
                {23,"Hyundai"},
                {24,"Kia"},
                {25,"Jaguar"},
                {26,"Land Rover"},
                {27,"Bentley"},
                {28,"Aston Martin"},
                {29,"Audi"},
                {30,"Porsche"},
                {31,"Volvo"},
                {32,"Ferrari"},
                {33,"Lamborghini"},
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