using System.Collections.Generic;
using System.IO;
using System.Linq;
using MicroHermes.Vehicles.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace MicroHermes.Vehicles.Core.Data.Queries
{
    public class VehicleQueries : IVehicleQueries
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IList<VehicleEntity> _vehicles;
        
        public VehicleQueries(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var jsonString = File.ReadAllText(contentRootPath + "/vehicles.json");

            _vehicles = JsonConvert.DeserializeObject<List<VehicleEntity>>(jsonString);

        }
        
        public VehicleEntity GetVehicleByVin(string vin)
        {
            return _vehicles.FirstOrDefault(x=>x.FullVin.Equals(vin));
        }

    }
}