using System;
using System.Linq;
using System.Net;
using MicroHermes.Core;
using MicroHermes.Core.Models;
using MicroHermes.Vehicles.Controllers;
using MicroHermes.Vehicles.Core.Data.Commands;
using MicroHermes.Vehicles.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Models;
using MicroHermes.Vehicles.Core.Validators;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Controllers
{
    public class PatchVehiclesControllerTests
    {
        private readonly PatchVehiclesController _controller;
        private readonly Mock<IVehicleQueries> _vehicleQueries;
        private readonly Mock<IVehicleCommands> _vehicleCommands;
        private readonly Mock<IVehicleEntityMapper> _vehicleEntityMapper;
        private readonly Mock<IVehicleModelValidation> _vehicleModelValidation;
        private readonly Mock<IVehicleModelMapper> _vehicleModelMapper;

        public PatchVehiclesControllerTests()
        {
            _vehicleQueries = new Mock<IVehicleQueries>();
            _vehicleCommands = new Mock<IVehicleCommands>();
            _vehicleEntityMapper = new Mock<IVehicleEntityMapper>();
            _vehicleModelValidation = new Mock<IVehicleModelValidation>();
            _vehicleModelMapper = new Mock<IVehicleModelMapper>();

            _controller = new PatchVehiclesController(_vehicleCommands.Object, _vehicleQueries.Object,
                _vehicleEntityMapper.Object, _vehicleModelValidation.Object, _vehicleModelMapper.Object);
        }

        private VehicleModel ValidModel => new VehicleModel
        {
            Year = 2015,
            Vin = "JM1CW2BLE0I106097"
        };

        private VehicleEntity ValidEntity => new VehicleEntity
        {
            YearId = 15,
            FullVin = "JM1CW2BLE0I106097",
            PartialVin = "JM1CW2BLE0"
        };

        [Fact]
        public void SDHP_PartialUpdate()
        {
            //Arrange
            var vin = "JM1CW2BLE0I106097";

            _vehicleModelValidation.Setup(x => x.Validate(It.IsAny<VehicleModel>())).Returns(true);
            _vehicleQueries.Setup(x => x.GetVehicleByVin(It.IsAny<string>())).Returns(ValidEntity);
            _vehicleCommands.Setup(x => x.UpdateVehicle(It.IsAny<VehicleEntity>())).Returns(true);
            
            //Act
            var result = _controller.PartialUpdateVehicle(vin, ValidModel) as OkObjectResult;
            var response = result.Value as HateoasResponseObject<VehicleModel>;
            
            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldNotEqual(null);
            result.StatusCode.ShouldEqual((int) HttpStatusCode.OK);
            result.Value.ShouldBeType<HateoasResponseObject<VehicleModel>>();

            response.Links.Count.ShouldEqual(2);
            response.Links.Count(x => x.Type.Equals(HttpVerbs.Put)).ShouldEqual(1);
            response.Links.Count(x => x.Type.Equals(HttpVerbs.Get)).ShouldEqual(1);

            var updateLink = response.Links.First(x => x.Type.Equals(HttpVerbs.Put));

            updateLink.Rel.ShouldNotBeNull();
            updateLink.Rel.ShouldNotBeEmpty();
            updateLink.Rel.ShouldEqual("vehicle.update.full");
            
            var getLink = response.Links.First(x => x.Type.Equals(HttpVerbs.Get));
            getLink.Rel.ShouldNotBeNull();
            getLink.Rel.ShouldNotBeEmpty();
            getLink.Rel.ShouldEqual("vehicle.get");
        }
    }
}