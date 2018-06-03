using System;
using MicroHermes.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Models;
using Moq;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Core.Mappers
{
    public class VehicleModelMapperTests
    {
        private readonly IVehicleModelMapper _vehicleModelMapper;

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

        public VehicleModelMapperTests()
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

            _vehicleModelMapper = new VehicleModelMapper(
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

        private VehicleModel ValidVehicleModelPartialUpdate => new VehicleModel
        {
            ExteriorColor = "Red",
            InteriorColor = "Yellow"
        };

        private VehicleModel ValidVehicleModelFullUpdate => new VehicleModel
        {
            Vin = "1B3AZ6EZAVV103745",
            Year = 2010,
            Make = "Dodge",
            Model = "Viper",
            Trim = "SRT-10 2dr Convertible ",
            EngineDescription = "8.4L 10 Cylinder",
            EngineSize = 8.4m,
            Transmission = "Manual",
            DriveTrain = "RWD",
            Body = "Convertible",
            Type = "Car",
            ExteriorColor = "Yellow",
            InteriorColor = "Orange"
        };

        [Fact]
        public void SDHP_PartialUpdate()
        {
            //Arrange
            var entity = ValidVehicleEntity;

            _vehicleInteriorColorQueries.Setup(x => x.GetId("Yellow")).Returns(19);
            _vehicleExteriorColorQueries.Setup(x => x.GetId("Red")).Returns(14);

            //Act
            _vehicleModelMapper.UpdateVehicleEntityFromModel(entity, ValidVehicleModelPartialUpdate, true);

            //Assert
            entity.ShouldNotBeNull();
            entity.FullVin.ShouldEqual("JM1CW2BLE0I106097");
            entity.PartialVin.ShouldEqual("JM1CW2BLE0");
            entity.YearId.ShouldEqual(14);
            entity.MakeId.ShouldEqual(16);
            entity.ModelId.ShouldEqual(216);
            entity.TrimId.ShouldEqual(1260);
            entity.EngineTypeId.ShouldEqual(25);
            entity.TransmissionId.ShouldEqual(4);
            entity.DriveTrainId.ShouldEqual(2);
            entity.BodyTypeId.ShouldEqual(13);
            entity.VehicleTypeId.ShouldEqual(5);
            entity.InteriorColorId.ShouldEqual(19);
            entity.ExteriorColorId.ShouldEqual(14);
        }

        [Fact]
        public void SDHP_FullUpdate()
        {
            //Arrange
            var entity = ValidVehicleEntity;

            _vehicleYearQueries.Setup(x => x.GetId(It.IsAny<int>())).Returns(10);
            _vehicleMakeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(4);
            _vehicleModelQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(8);
            _vehicleTrimQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(62);
            _vehicleEngineTypeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(12);
            _vehicleTransmissionQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(2);
            _vehicleDriveTrainQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(4);
            _vehicleBodyTypeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(5);
            _vehicleVehicleTypeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(2);
            _vehicleInteriorColorQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(11);
            _vehicleExteriorColorQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(18);

            //Act
            _vehicleModelMapper.UpdateVehicleEntityFromModel(entity, ValidVehicleModelFullUpdate);

            //Assert
            entity.ShouldNotBeNull();
            entity.FullVin.ShouldEqual("1B3AZ6EZAVV103745");
            entity.PartialVin.ShouldEqual("1B3AZ6EZAV");
            entity.YearId.ShouldEqual(10);
            entity.MakeId.ShouldEqual(4);
            entity.ModelId.ShouldEqual(8);
            entity.TrimId.ShouldEqual(62);
            entity.EngineTypeId.ShouldEqual(12);
            entity.TransmissionId.ShouldEqual(2);
            entity.DriveTrainId.ShouldEqual(4);
            entity.BodyTypeId.ShouldEqual(5);
            entity.VehicleTypeId.ShouldEqual(2);
            entity.InteriorColorId.ShouldEqual(11);
            entity.ExteriorColorId.ShouldEqual(18);
        }

        [Fact]
        public void Fail_FullUpdate()
        {
            //Arrange
            var entity = ValidVehicleEntity;

            _vehicleYearQueries.Setup(x => x.GetId(It.IsAny<int>())).Returns(10);
            _vehicleMakeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(4);
            _vehicleModelQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(8);
            _vehicleTrimQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(62);
            _vehicleEngineTypeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(12);
            _vehicleTransmissionQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(2);
            _vehicleDriveTrainQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(4);
            _vehicleBodyTypeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(5);
            _vehicleVehicleTypeQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(2);
            _vehicleInteriorColorQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(11);
            _vehicleExteriorColorQueries.Setup(x => x.GetId(It.IsAny<string>())).Returns(18);

            //Act
            var act = new Action(() => _vehicleModelMapper.UpdateVehicleEntityFromModel(entity, ValidVehicleModelPartialUpdate));

            //Assert
            act.ShouldThrow<NullReferenceException>();
        }
    }
}