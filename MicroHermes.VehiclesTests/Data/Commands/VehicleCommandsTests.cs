using MicroHermes.Vehicles.Core.Data.Commands;
using MicroHermes.Vehicles.Core.Entities;
using Moq;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Data.Commands
{
    public class VehicleCommandsTests
    {
        private readonly IVehicleCommands _vehicleCommands;

        public VehicleCommandsTests()
        {
            _vehicleCommands = new VehicleCommands();
        }

        [Fact]
        public void SDHP_UpdateVehicle()
        {
            //Arrange
            var entity = new VehicleEntity();

            //Act
            var result = _vehicleCommands.UpdateVehicle(entity);

            //Assert
            result.ShouldBeTrue();
        }
    }
}