using System.Net;
using MicroHermes.Core.Models;
using MicroHermes.Vehicles.Controllers;
using MicroHermes.Vehicles.Core.Data.Commands;
using MicroHermes.Vehicles.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Controllers
{
    public class VehiclesControllerTests
    {
        private readonly GetVehiclesController _controller;
        private readonly Mock<IVehicleQueries> _vehicleQueries;
        private readonly Mock<IVehicleCommands> _vehicleCommands;
        private readonly Mock<IVehicleEntityMapper> _vehicleEntityMapper;
        
        public VehiclesControllerTests()
        {
            _vehicleQueries = new Mock<IVehicleQueries>();
            _vehicleCommands = new Mock<IVehicleCommands>();
            _vehicleEntityMapper = new Mock<IVehicleEntityMapper>();
            
            _controller = new GetVehiclesController(_vehicleCommands.Object, _vehicleQueries.Object, _vehicleEntityMapper.Object);
        }

        #region Setup

        private VehicleModel ValidVehicleModel => new VehicleModel { Vin = "JM1CW2BLE0I106097"};
        private VehicleEntity ValidVehicleEntity => new VehicleEntity {FullVin = "JM1CW2BLE0I106097"};

        #endregion Setup


        [Fact]
        public void SDHP_GetVehicle()
        {
            //Arrange
            var vin = "JM1CW2BLE0I106097";

            _vehicleQueries.Setup(x => x.GetVehicleByVin(It.IsAny<string>())).Returns(ValidVehicleEntity);
            _vehicleEntityMapper.Setup(x => x.ToVehicleModel(It.IsAny<VehicleEntity>())).Returns(ValidVehicleModel);
            
            //Act
            var result = _controller.GetVehicle(vin) as OkObjectResult;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldNotEqual(null);
            result.StatusCode.ShouldEqual((int) HttpStatusCode.OK);
            result.Value.ShouldBeType<HateoasResponseObject<VehicleModel>>();
        }
        
        [Fact]
        public void Fail_GetVehicle_NotFound()
        {
            //Arrange
            var vin = "JM1CW2BLE0I106097";

            _vehicleQueries.Setup(x => x.GetVehicleByVin(It.IsAny<string>())).Returns((VehicleEntity)null);
            
            //Act
            var result = _controller.GetVehicle(vin) as NotFoundObjectResult;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldNotEqual(null);
            result.StatusCode.ShouldEqual((int) HttpStatusCode.NotFound);
        }
        
        [Fact]
        public void Fail_GetVehicle_InvalidVin_Too_Long()
        {
            //Arrange
            var vin = "JM1CW2BLE0I106097SDJDFKSHD8ND8W09HPI";
            
            _vehicleQueries.Setup(x => x.GetVehicleByVin(It.IsAny<string>())).Returns((VehicleEntity)null);
            
            //Act
            var result = _controller.GetVehicle(vin) as BadRequestObjectResult;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldNotEqual(null);
            result.StatusCode.ShouldEqual((int) HttpStatusCode.BadRequest);
            result.Value.ShouldEqual(vin);
        }
        
        [Fact]
        public void Fail_GetVehicle_InvalidVin_Too_Short()
        {
            //Arrange
            var vin = "J";
            
            _vehicleQueries.Setup(x => x.GetVehicleByVin(It.IsAny<string>())).Returns((VehicleEntity)null);
            
            //Act
            var result = _controller.GetVehicle(vin) as BadRequestObjectResult;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldNotEqual(null);
            result.StatusCode.ShouldEqual((int) HttpStatusCode.BadRequest);
            result.Value.ShouldEqual(vin);
        }
        
        [Fact]
        public void Fail_GetVehicle_InvalidVin_Null()
        {
            //Arrange
            string vin = null;
            
            _vehicleQueries.Setup(x => x.GetVehicleByVin(It.IsAny<string>())).Returns((VehicleEntity)null);
            
            //Act
            var result = _controller.GetVehicle(vin) as BadRequestObjectResult;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldNotEqual(null);
            result.StatusCode.ShouldEqual((int) HttpStatusCode.BadRequest);
            result.Value.ShouldEqual(vin);
        }
    }
}