using MicroHermes.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Mappers
{
    public class VehicleEntityMapper : IVehicleEntityMapper
    {
        private readonly IVehicleYearQueries _vehicleYearQueries;
        private readonly IVehicleMakeQueries _vehicleMakeQueries;
        private readonly IVehicleModelQueries _vehicleModelQueries;
        private readonly IVehicleTrimQueries _vehicleTrimQueries;
        private readonly IVehicleEngineTypeQueries _vehicleEngineTypeQueries;
        private readonly IVehicleTransmissionQueries _vehicleTransmissionQueries;
        private readonly IVehicleDriveTrainQueries _vehicleDriveTrainQueries;
        private readonly IVehicleBodyTypeQueries _vehicleBodyTypeQueries;
        private readonly IVehicleVehicleTypeQueries _vehicleVehicleTypeQueries;
        private readonly IVehicleInteriorColorQueries _vehicleInteriorColorQueries;
        private readonly IVehicleExteriorColorQueries _vehicleExteriorColorQueries;

        public VehicleEntityMapper(IVehicleYearQueries vehicleYearQueries,
            IVehicleMakeQueries vehicleMakeQueries,
            IVehicleModelQueries vehicleModelQueries,
            IVehicleTrimQueries vehicleTrimQueries,
            IVehicleEngineTypeQueries vehicleEngineTypeQueries,
            IVehicleTransmissionQueries vehicleTransmissionQueries,
            IVehicleDriveTrainQueries vehicleDriveTrainQueries,
            IVehicleBodyTypeQueries vehicleBodyTypeQueries,
            IVehicleVehicleTypeQueries vehicleVehicleTypeQueries,
            IVehicleInteriorColorQueries vehicleInteriorColorQueries,
            IVehicleExteriorColorQueries vehicleExteriorColorQueries)
        {
            _vehicleYearQueries = vehicleYearQueries;
            _vehicleMakeQueries = vehicleMakeQueries;
            _vehicleModelQueries = vehicleModelQueries;
            _vehicleTrimQueries = vehicleTrimQueries;
            _vehicleEngineTypeQueries = vehicleEngineTypeQueries;
            _vehicleTransmissionQueries = vehicleTransmissionQueries;
            _vehicleDriveTrainQueries = vehicleDriveTrainQueries;
            _vehicleBodyTypeQueries = vehicleBodyTypeQueries;
            _vehicleVehicleTypeQueries = vehicleVehicleTypeQueries;
            _vehicleInteriorColorQueries = vehicleInteriorColorQueries;
            _vehicleExteriorColorQueries = vehicleExteriorColorQueries;
        }

        public VehicleModel ToVehicleModel(VehicleEntity entity)
        {
            var model = new VehicleModel
            {
                Vin = entity.FullVin,
                Year = _vehicleYearQueries.GetValue(entity.YearId),
                Make = _vehicleMakeQueries.GetValue(entity.MakeId),
                Model = _vehicleModelQueries.GetValue(entity.ModelId),
                Trim = _vehicleTrimQueries.GetValue(entity.TrimId),
                EngineDescription = _vehicleEngineTypeQueries.GetValue(entity.EngineTypeId),
                Transmission = _vehicleTransmissionQueries.GetValue(entity.TransmissionId),
                DriveTrain = _vehicleDriveTrainQueries.GetValue(entity.DriveTrainId),
                Body = _vehicleBodyTypeQueries.GetValue(entity.BodyTypeId),
                Type = _vehicleVehicleTypeQueries.GetValue(entity.VehicleTypeId),
                ExteriorColor = _vehicleExteriorColorQueries.GetValue(entity.ExteriorColorId),
                InteriorColor = _vehicleInteriorColorQueries.GetValue(entity.InteriorColorId),
            };

            if (decimal.TryParse(model.EngineDescription.Split('L')[0], out var engineSize))
            {
                model.EngineSize = engineSize;                
            }
            
            return model;
        }
    }
}