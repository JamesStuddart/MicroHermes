using System;

namespace MicroHermes.Vehicles.Core.Models
{
    public class VehicleModel
    {
        public string Vin { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string EngineDescription { get; set; }
        public decimal? EngineSize { get; set; }
        public string Transmission { get; set; }
        public string DriveTrain { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
    }
}