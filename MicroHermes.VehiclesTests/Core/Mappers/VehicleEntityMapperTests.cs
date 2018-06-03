using MicroHermes.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Models;
using Moq;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Core.Mappers
{
    public class VehicleEntityMapperTests
    {
        private readonly IVehicleEntityMapper _vehicleEntityMapper;

        private readonly Mock<IVehicleYearQueries> _vehicleYearQueries;
        private readonly Mock<IVehicleMakeQueries> _vehicleMakeQueries;
        private readonly Mock<IVehicleModelQueries> _vehicleModelQueries;
        private readonly Mock<IVehicleTrimQueries> _vehicleTrimQueries;
        private readonly Mock<IVehicleEngineTypeQueries> _vehicleEngineTypeQueries;
        private readonly Mock<IVehicleTransmissionQueries> _vehicleTransmissionQueries;
        private readonly Mock<IVehicleDriveTrainQueries> _vehicleDriveTrainQueries;
        private readonly Mock<IVehicleBodyTypeQueries> _vehicleBodyTypeQueries;
        private readonly Mock<IVehicleVehicleTypeQueries> _vehicleVehicleTypeQueries;
        private readonly Mock<IVehicleInteriorColorQueries> _vehicleInteriorColorQueries;
        private readonly Mock<IVehicleExteriorColorQueries> _vehicleExteriorColorQueries;

        public VehicleEntityMapperTests()
        {
            _vehicleYearQueries = new Mock<IVehicleYearQueries>();
            _vehicleMakeQueries = new Mock<IVehicleMakeQueries>();
            _vehicleModelQueries = new Mock<IVehicleModelQueries>();
            _vehicleTrimQueries = new Mock<IVehicleTrimQueries>();
            _vehicleEngineTypeQueries = new Mock<IVehicleEngineTypeQueries>();
            _vehicleTransmissionQueries = new Mock<IVehicleTransmissionQueries>();
            _vehicleDriveTrainQueries = new Mock<IVehicleDriveTrainQueries>();
            _vehicleBodyTypeQueries = new Mock<IVehicleBodyTypeQueries>();
            _vehicleVehicleTypeQueries = new Mock<IVehicleVehicleTypeQueries>();
            _vehicleInteriorColorQueries = new Mock<IVehicleInteriorColorQueries>();
            _vehicleExteriorColorQueries = new Mock<IVehicleExteriorColorQueries>();

            _vehicleEntityMapper = new VehicleEntityMapper(
                _vehicleYearQueries.Object,
                _vehicleMakeQueries.Object,
                _vehicleModelQueries.Object,
                _vehicleTrimQueries.Object,
                _vehicleEngineTypeQueries.Object,
                _vehicleTransmissionQueries.Object,
                _vehicleDriveTrainQueries.Object,
                _vehicleBodyTypeQueries.Object,
                _vehicleVehicleTypeQueries.Object,
                _vehicleInteriorColorQueries.Object,
                _vehicleExteriorColorQueries.Object);
        }
        
        private VehicleEntity ValidVehicleEntity => new VehicleEntity
        {
            FullVin = "JM1CW2BLE0I106097",
            PartialVin = "JM1CW2BLE0",
            YearId = 14,
            MakeId = 16,
            ModelId = 216,
            TrimId = 1260,
            EngineTypeId = 25,
            TransmissionId = 4,
            DriveTrainId = 2,
            BodyTypeId = 13,
            VehicleTypeId = 5,
            ExteriorColorId = 3,
            InteriorColorId = 2
        };
        
        private VehicleModel ValidVehicleModel => new VehicleModel
        {
            Vin = "JM1CW2BLE0I106097",
            Year = 2014,
            Make = "Mazda",
            Model = "5",
            Trim = "Sport 4dr Minivan ",
            EngineDescription = "2.5L 4 Cylinder",
            EngineSize = 2.5m,
            Transmission = "Unknown",
            DriveTrain = "FWD",
            Body = "Passenger Minivan",
            Type = "MiniVan",
            ExteriorColor = "Black",
            InteriorColor = "Blue"
        };
        
        [Fact]
        public void SDHP_ToVehicleModel()
        {
            //Arrange
            _vehicleYearQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns(2014);
            _vehicleMakeQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("Mazda");
            _vehicleModelQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("5");
            _vehicleTrimQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("Sport 4dr Minivan ");
            _vehicleEngineTypeQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("2.5L 4 Cylinder");
            _vehicleTransmissionQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("Unknown");
            _vehicleDriveTrainQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("FWD");
            _vehicleBodyTypeQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("Passenger Minivan");
            _vehicleVehicleTypeQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("MiniVan");
            _vehicleExteriorColorQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("Black");
            _vehicleInteriorColorQueries.Setup(x=>x.GetValue(It.IsAny<int>())).Returns("Blue");
            
            //Assert
            var model = _vehicleEntityMapper.ToVehicleModel(ValidVehicleEntity);
            
            //Act
            model.Vin.ShouldEqual(ValidVehicleModel.Vin);
            model.Year.ShouldEqual(ValidVehicleModel.Year);
            model.Make.ShouldEqual(ValidVehicleModel.Make);
            model.Model.ShouldEqual(ValidVehicleModel.Model);
            model.Trim.ShouldEqual(ValidVehicleModel.Trim);
            model.EngineDescription.ShouldEqual(ValidVehicleModel.EngineDescription);
            model.EngineSize.ShouldEqual(ValidVehicleModel.EngineSize);
            model.Transmission.ShouldEqual(ValidVehicleModel.Transmission);
            model.DriveTrain.ShouldEqual(ValidVehicleModel.DriveTrain);
            model.Body.ShouldEqual(ValidVehicleModel.Body);
            model.Type.ShouldEqual(ValidVehicleModel.Type);
            model.ExteriorColor.ShouldEqual(ValidVehicleModel.ExteriorColor);
            model.InteriorColor.ShouldEqual(ValidVehicleModel.InteriorColor);
        }
    }
}