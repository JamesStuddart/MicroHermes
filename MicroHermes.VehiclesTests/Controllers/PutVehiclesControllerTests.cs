using MicroHermes.Vehicles.Controllers;
using MicroHermes.Vehicles.Core.Data.Commands;
using MicroHermes.Vehicles.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Validators;
using Moq;

namespace MicroHermes.VehiclesTests.Controllers
{
    public class PutVehiclesControllerTests
    {
        private readonly PutVehiclesController _controller;
        private readonly Mock<IVehicleQueries> _vehicleQueries;
        private readonly Mock<IVehicleCommands> _vehicleCommands;
        private readonly Mock<IVehicleEntityMapper> _vehicleEntityMapper;
        private readonly Mock<IVehicleModelValidation> _vehicleModelValidation;
        private readonly Mock<IVehicleModelMapper> _vehicleModelMapper;
        
        public PutVehiclesControllerTests()
        {
            _vehicleQueries = new Mock<IVehicleQueries>();
            _vehicleCommands = new Mock<IVehicleCommands>();
            _vehicleEntityMapper = new Mock<IVehicleEntityMapper>();
            _vehicleModelValidation = new Mock<IVehicleModelValidation>();
            _vehicleModelMapper = new Mock<IVehicleModelMapper>();
            
            _controller = new PutVehiclesController(_vehicleCommands.Object, _vehicleQueries.Object, _vehicleEntityMapper.Object, _vehicleModelValidation.Object, _vehicleModelMapper.Object);
        }
    }
}