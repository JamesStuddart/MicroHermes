using MicroHermes.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Mappers
{
    public class VehicleModelMapper : IVehicleModelMapper
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

        public VehicleModelMapper(IVehicleYearQueries vehicleYearQueries,
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
        
        public void UpdateVehicleEntityFromModel(VehicleEntity entity, VehicleModel model, bool partialUpdate = false)
        {
            if (partialUpdate)
            {
                PartialUpdate(entity, model);
            }
            else
            {
                FullUpdate(entity, model);
            }
        }

        private void PartialUpdate(VehicleEntity entity, VehicleModel model)
        {
            entity.FullVin = model.Vin ?? entity.FullVin;
            entity.PartialVin = model.Vin != null ? model.Vin.Substring(0,9) : entity.PartialVin;
            entity.YearId = model.Year != null ? _vehicleYearQueries.GetId(model.Year.Value) : entity.YearId;
            entity.MakeId = model.Make != null ? _vehicleMakeQueries.GetId(model.Make) : entity.MakeId;
            entity.ModelId = model.Model != null ? _vehicleModelQueries.GetId(model.Model) : entity.ModelId;
            entity.TrimId = model.Trim != null ? _vehicleTrimQueries.GetId(model.Trim) : entity.TrimId;
            entity.EngineTypeId = model.EngineDescription != null ? _vehicleEngineTypeQueries.GetId(model.EngineDescription) : entity.EngineTypeId;
            entity.TransmissionId = model.Transmission != null ? _vehicleTransmissionQueries.GetId(model.Transmission) : entity.TransmissionId;
            entity.DriveTrainId = model.DriveTrain != null ? _vehicleDriveTrainQueries.GetId(model.DriveTrain) : entity.DriveTrainId;
            entity.BodyTypeId = model.Body != null ? _vehicleBodyTypeQueries.GetId(model.Body) : entity.BodyTypeId;
            entity.VehicleTypeId = model.Type != null ? _vehicleVehicleTypeQueries.GetId(model.Type) : entity.VehicleTypeId;
            entity.InteriorColorId = model.InteriorColor != null ? _vehicleInteriorColorQueries.GetId(model.InteriorColor) : entity.InteriorColorId;
            entity.ExteriorColorId = model.ExteriorColor != null ? _vehicleExteriorColorQueries.GetId(model.ExteriorColor) : entity.ExteriorColorId;
        }
        
        private void FullUpdate(VehicleEntity entity, VehicleModel model)
        {
            entity.FullVin = model.Vin;
            entity.PartialVin = model.Vin.Substring(0,9);
            entity.YearId = _vehicleYearQueries.GetId(model.Year.Value);
            entity.MakeId = _vehicleMakeQueries.GetId(model.Make);
            entity.ModelId = _vehicleModelQueries.GetId(model.Model);
            entity.TrimId = _vehicleTrimQueries.GetId(model.Trim);
            entity.EngineTypeId = _vehicleEngineTypeQueries.GetId(model.EngineDescription);
            entity.TransmissionId = _vehicleTransmissionQueries.GetId(model.Transmission);
            entity.DriveTrainId = _vehicleDriveTrainQueries.GetId(model.DriveTrain);
            entity.BodyTypeId = _vehicleBodyTypeQueries.GetId(model.Body);
            entity.VehicleTypeId = _vehicleVehicleTypeQueries.GetId(model.Type);
            entity.InteriorColorId = _vehicleInteriorColorQueries.GetId(model.InteriorColor);
            entity.ExteriorColorId = _vehicleExteriorColorQueries.GetId(model.ExteriorColor);
        }
    }
}