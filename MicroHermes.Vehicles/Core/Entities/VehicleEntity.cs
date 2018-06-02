namespace MicroHermes.Vehicles.Core.Entities
{
    public class VehicleEntity
    {
        public int Id { get; set; }
        public string PartialVin { get; set; }
        public string FullVin { get; set; }
        public int YearId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int TrimId { get; set; }
        public int EngineTypeId { get; set; }
        public int TransmissionId { get; set; }
        public int DriveTrainId { get; set; }
        public int BodyTypeId { get; set; }
        public int VehicleTypeId { get; set; }
        public int InteriorColorId { get; set; }
        public int ExteriorColorId { get; set; }
    }
}